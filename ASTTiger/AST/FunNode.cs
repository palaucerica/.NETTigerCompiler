using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace ASTTiger
{
    public class FunctionNode : FunDeclarationNode
    {
        public List<Tuple<string,string>> Param { get; private set; }

        public string Name { get; private set; }
        public string Retu { get; private set; }
        public List<Tuple<string, Var_Scope>> types = new List<Tuple<string, Var_Scope>>();//guardo todos los TypeReturn de los parámetros
        TypeBuilder typeClass;
        TypeReturn resul;//resultado de la función
        Fun_Scope f;

        public FunctionNode(string name, List<Tuple<string,string>> param,string retu) 
        {
            Param = param;
            Name = name;
            Retu = retu;
        }

        public override bool CheckHeader(List<Scope> scope_list, List<Error> errors)
        {
            int cant = errors.Count();//ver los errores que hay hasta el momento

            if (Utils.IsStandardFunction(scope_list[0], Name))
                errors.Add(new Error(line, column, "Hay una funcion en la libreria estandar con el nombre '" + Name + "'"));

            else if (scope_list[scope_list.Count - 1].Vars.ContainsKey(Name) ||
                scope_list[scope_list.Count - 1].Funcs.ContainsKey(Name))//ver si no hay una funcion o variable con ese nombre
                errors.Add(new Error(line, column, "El nombre de la función '" + Name + "' ya esta en uso"));//añado el error

            resul = Utils.FindType(scope_list, Retu);
            if (resul == null)//ver si el "tipo" existe
                errors.Add(new Error(line, column, "El tipo de retorno de la función '" + Name + "' no existe"));//añado el error

            Dictionary<string, string> e = new Dictionary<string, string>();//para saber cuales son los parámetros y no repetir
            TypeReturn temp=null;
            foreach (var p in Param)
            {
                temp=Utils.FindType(scope_list, p.Item2);
                if (temp == null)//ver si el "tipo" existe
                    errors.Add(new Error(line, column, "El tipo del parámetro '" + p.Item1 + "' de la función no existe"));//añado el error
                else types.Add(new Tuple<string, Var_Scope>(p.Item1,new Var_Scope(p.Item1,temp)));

                if (Param.Where(x => x.Item1 == p.Item1).Count() > 1 && !e.ContainsKey(p.Item1))//hay mas de uno con el mismo nombre y si no lo he visto
                {
                    errors.Add(new Error(line, column, "Existe más de un parámetro con el nombre '" + Name + "'"));//añado el error
                    e.Add(p.Item1, p.Item1);//añado el nombre del parámetro al diccionario
                }
            }

            if (cant == errors.Count)//ver si no hubo error
            {
                f=new Fun_Scope(Name, types.Select(x=> new Tuple<string,TypeReturn>(x.Item1,x.Item2.Var_type)).ToList(), resul);
                scope_list[scope_list.Count - 1].Funcs.Add(Name,f);//añadir la función al scope 
                return false;
            }
            return true;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            Scope s = new Scope();

            foreach (var p in types)            
                s.Vars.Add(p.Item1, p.Item2);
            scope_list.Add(s);

            TypeReturn r = Body.CheckSemantics(scope_list, errors);

            if (r != null && r is ReturnNil)//ver si el valor de retorno es distinto a lo que deberia devolver
            {
                if(Retu=="int")
                errors.Add(new Error(line, column, "No coincide el tipo de retorno con el que debería retornar"));
            }
            else if (r != null && r.ToString() != Retu)            
                errors.Add(new Error(line, column, "No coincide el tipo de retorno con el que debería retornar"));            

            scope_list.RemoveAt(scope_list.Count - 1);

            return new ReturnNotValue();
        }

        public override void CreateType(TypeBuilder parent)
        {
            //Parametros ,empezando por el padre
            List<Type> param = new List<Type>() { parent };
            param.AddRange(types.Select(a => a.Item2.Var_type.MyType()));

            typeClass = parent.DefineNestedType(Name + Utils.AutoNumeric, TypeAttributes.NestedPublic | TypeAttributes.Class);

            ConstructorBuilder constructor = typeClass.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, param.ToArray());           
            f.constr = constructor;

            MethodBuilder mFunc = typeClass.DefineMethod(Name, MethodAttributes.Public, CallingConventions.HasThis, resul.MyType(), new Type[] { });
            f.meth = mFunc;
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {       
            ILGenerator ctor1IL = f.constr.GetILGenerator();
            FieldBuilder field = null;

            //esto es para la referencia al padre
            field = typeClass.DefineField("parent", parent, FieldAttributes.Public);
            ctor1IL.Emit(OpCodes.Ldarg_0); //meto el this
            ctor1IL.Emit(OpCodes.Ldarg_1);//meto el padre en la pila
            ctor1IL.Emit(OpCodes.Stfld, field);

            level.Add(field);

            for (int i = 1; i <= types.Count; i++)
            {
                field = typeClass.DefineField(types[i - 1].Item1, types[i - 1].Item2.Var_type.MyType(), FieldAttributes.Public);
                ctor1IL.Emit(OpCodes.Ldarg_0); //meto el this
                ctor1IL.Emit(OpCodes.Ldarg, i+1); //meto el argumento i-esimo a la pila
                ctor1IL.Emit(OpCodes.Stfld, field); //asigna el valor del argumento al campo field
                types[i - 1].Item2.VarbBuilder = field;
            }

            field = typeClass.DefineField("Break", typeof(bool), FieldAttributes.Public);
            ctor1IL.Emit(OpCodes.Ldarg_0); //meto el this
            ctor1IL.Emit(OpCodes.Ldc_I4_0);//meto un cero en la pila
            ctor1IL.Emit(OpCodes.Stfld, field);

            ctor1IL.Emit(OpCodes.Ret);

            //Creo el metodo en el que se encuentra el cuerpo de la función
            ILGenerator ilFunc = f.meth.GetILGenerator();
            
            Body.GenCode(ilFunc, typeClass,field,level, endLabel);            
            ilFunc.Emit(OpCodes.Ret);

            // Crear la clase para la funcion.
            typeClass.CreateType();

            level.RemoveAt(level.Count - 1);
            return null;
        }
    }
}
