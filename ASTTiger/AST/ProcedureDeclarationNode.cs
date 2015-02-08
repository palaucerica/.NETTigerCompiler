using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace ASTTiger
{
    public class ProcedureDeclarationNode : FunDeclarationNode
    {
        public List<Tuple<string,string>> Param { get; private set; }
        public string Name { get; private set; }
        public List<Tuple<string, Var_Scope>> types = new List<Tuple<string, Var_Scope>>();//guardo todos los TypeReturn de los par
        TypeBuilder typeClass;
        Fun_Scope f;

        public ProcedureDeclarationNode(string name, List<Tuple<string,string>> param) 
        {
            Param = param;
            Name = name;
        }

        public override bool CheckHeader(List<Scope> scope_list, List<Error> errors)
        {
            int cant = errors.Count();//ver los errores que hay hasta el momento

            if (scope_list[scope_list.Count - 1].Vars.ContainsKey(Name) ||
                scope_list[scope_list.Count - 1].Funcs.ContainsKey(Name))//ver si no hay una funcion o variable con ese nombre
                errors.Add(new Error(line, column, "El nombre de la función '" + Name + "' ya esta en uso"));//añado el error

            TypeReturn temp = null;
            Dictionary<string, string> e = new Dictionary<string, string>();
            foreach (var p in Param)
            {
                temp = Utils.FindType(scope_list, p.Item2);
                if (temp == null)//ver si el "tipo" existe
                    errors.Add(new Error(line, column, "El tipo del parámetro '" + p.Item1 + "' de la función no existe"));//añado el error
                else types.Add(new Tuple<string, Var_Scope>(p.Item1,new Var_Scope(p.Item1,temp)));

                if (Param.Where(x => x.Item1 == p.Item1).Count() > 1 && !e.ContainsKey(p.Item1))//hay mas de uno con el mismo nombre y no lo he visto
                {
                    errors.Add(new Error(line, column, "Existe más de un parámetro con el nombre '" + p.Item1 + "'"));//añado el error
                    e.Add(p.Item1, p.Item1);//añado el nombre del parametro al diccionario
                }
            }

            if (cant == errors.Count)//ver si no hubo error
            {
                f= new Fun_Scope(Name, types.Select(x => new Tuple<string, TypeReturn>(x.Item1, x.Item2.Var_type)).ToList(), new ReturnNotValue());
                scope_list[scope_list.Count - 1].Funcs.Add(Name,f);//añadir el procedimiento al scope
                return false;
            }
            else return true;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            Scope s = new Scope();

            foreach (var p in types)
                s.Vars.Add(p.Item1, p.Item2);
            scope_list.Add(s);

            TypeReturn typeOfBody = Body.CheckSemantics(scope_list, errors);            
            if(typeOfBody == null) //pregunto si hubo problemas con el body del procedimiento
                return null;
            if (typeOfBody.ToString() != "No valor")//ver que no retorna valor
                errors.Add(new Error(line, column, "El procedimiento '"+Name+"' no debe retornar valor"));

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

            MethodBuilder mFunc = typeClass.DefineMethod(Name, MethodAttributes.Public, CallingConventions.HasThis, typeof(void), new Type[] { });
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
                ctor1IL.Emit(OpCodes.Ldarg, i + 1); //meto el argumento i-esimo a la pila
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
           
            Body.GenCode(ilFunc, typeClass, field, level, endLabel);
            ilFunc.Emit(OpCodes.Ret);

            // Crear la clase para la funcion.
            typeClass.CreateType();

            level.RemoveAt(level.Count - 1);
            return null;
        }
    }
}
