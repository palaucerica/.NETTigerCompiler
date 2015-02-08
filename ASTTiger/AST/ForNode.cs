using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace ASTTiger
{
    public class ForNode : ControlNode
    {
        public LanguageNode Body { get; private set; }
        public LanguageNode To { get; private set; }
        public LanguageNode Asig { get; private set; }
        public string Name { get; private set; }
        Var_Scope varFor;

        public ForNode(string name, LanguageNode asig, LanguageNode to, LanguageNode body)
        {
            Name = name;
            Asig = asig;
            To = to;
            if (body == null)
                Body = new ExpSeqNode(new List<LanguageNode>());
            else
                Body = body;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            countOfClicles++;
            bool problem = false; //para no meter una variable que esta mal en el Scope
            //hay que ver que no exista una variable ni una funcion con el mismo nombre que la del for
            foreach (Scope scope in scope_list)
            {
                if (scope.Vars.Any(s => s.Key.Equals(this.Name))) //pregunto por las variables
                {
                    errors.Add(new Error(line, column, "Ya existe una variable con el nombre: " + Name));
                    problem = true; //no puedo anadirla porque ya existe
                }
                else if (scope.Funcs.Any(s => s.Key.Equals(this.Name))) //pregunto por las funciones
                {
                    errors.Add(new Error(line, column, "Ya existe una funcion con el nombre: " + Name));
                    problem = true; //no puedo anadirla porque ya existe
                }
            }

            TypeReturn typeOfAsign = Asig.CheckSemantics(scope_list, errors);
            if (!(typeOfAsign is ReturnInt))
            {
                errors.Add(new Error(line, column, "La expresion de asignacion debe retonar un entero"));
                problem = true; //no puedo anadirla porque la variable no es un entero
            }

            TypeReturn typeOfTo = To.CheckSemantics(scope_list, errors);
            if (!(typeOfTo is ReturnInt))
                errors.Add(new Error(line, column, "La expresion del To debe retornar un entero"));
            
            if (!problem) //si no preguntara esto podria estar anadiendo una variable con problemas al Scope (en el Scope no hay nada con errores!)
            {
                varFor = new Var_Scope(Name, typeOfAsign,true);
                Dictionary<string, Var_Scope> param = new Dictionary<string, Var_Scope>();
                param.Add(Name, varFor);
                Scope scopeBodyFor = new Scope(param, new Dictionary<string, TypeReturn>(), new Dictionary<string, Fun_Scope>()); //el scope para la variable del for

                scope_list.Add(scopeBodyFor); //agrego la variable del for a la lista de scope para que el body del for pueda verla
                               
                //if(Body!=null)
                TypeReturn typeOfBody = Body.CheckSemantics(scope_list, errors);
                if (!(typeOfBody is ReturnNotValue))
                    errors.Add(new Error(line, column, "La expresion del body del for no debe devolver nada"));
                scope_list.Remove(scopeBodyFor); //remuevo la variable del for
            }

            countOfClicles--;
            return new ReturnNotValue();
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            //creo una clase para el for
            TypeBuilder forClass = parent.DefineNestedType("For" + Utils.AutoNumeric, TypeAttributes.NestedPublic | TypeAttributes.Class); //defino la clase anidada
            ConstructorBuilder forConstructor = forClass.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new List<Type>() { parent , typeof(int), typeof(int)}.ToArray());
            ILGenerator ilFor = forConstructor.GetILGenerator(); //cojo el generador de la clase del for

            //creando el campo 'parent'
            FieldBuilder forParent = forClass.DefineField("parent", parent, FieldAttributes.Public); //defino el campo parent del for
            ilFor.Emit(OpCodes.Ldarg_0); //meto el this
            ilFor.Emit(OpCodes.Ldarg_1); //meto el padre en la pila
            ilFor.Emit(OpCodes.Stfld, forParent); //el padre ahora es el for (this.parent = forParent)

            //creando el campo 'Break'
            FieldBuilder field = forClass.DefineField("Break", typeof(bool), FieldAttributes.Public);
            ilFor.Emit(OpCodes.Ldarg_0); //meto el this
            ilFor.Emit(OpCodes.Ldc_I4_0); //meto un cero en la pila
            ilFor.Emit(OpCodes.Stfld, field); //crea el campo con false

            //creando el campo del i
            FieldBuilder index = forClass.DefineField(Name, typeof(int), FieldAttributes.Public); //i del for (de la clase)
            
            ilFor.Emit(OpCodes.Ldarg_0); //meto el this
            ilFor.Emit(OpCodes.Ldarg_2); //meto el padre en la pila
            ilFor.Emit(OpCodes.Stfld, index); //el padre ahora es el for (this.parent = forParent)
            //Type asignType = Asig.GenCode(ilFor, forClass, field,level, endLabel); //genero el codigo de la asignacion (mete la asignacion en la pila)
            
            //ilFor.Emit(OpCodes.Stfld, index); //actualizo el valor de la asignacion
            varFor.VarbBuilder = index;

            //creando el to del for
            FieldBuilder toBuilder = forClass.DefineField("To" + Utils.AutoNumeric, typeof(int), FieldAttributes.Public);
            //LocalBuilder to = ilFor.DeclareLocal(typeof(int)); //declaro el to del for (para quedarme con el valor)

            ilFor.Emit(OpCodes.Ldarg_0); //meto el this
            ilFor.Emit(OpCodes.Ldarg_3); //meto el padre en la pila
            ilFor.Emit(OpCodes.Stfld, toBuilder); //el padre ahora es el for (this.parent = forParent)
            //Type toType = To.GenCode(ilFor, forClass, field, level, endLabel); //en el tope esta el valor del to
            
            //ilFor.Emit(OpCodes.Stfld, toBuilder); //actualizo el valor de la asignacion

            //Cerrar el constructor
            ilFor.Emit(OpCodes.Ret);

            //creo el metodo donde se encuentra el body
            MethodBuilder bodyBuilder = forClass.DefineMethod("ForBody", MethodAttributes.Public, CallingConventions.HasThis, typeof(void), new Type[] { });
            ILGenerator ilBody = bodyBuilder.GetILGenerator();

            //comienza la generacion de codigo del for
            Label start = ilBody.DefineLabel();
            Label end = ilBody.DefineLabel();
            //comienza el for
            //meto en el tope el campo this.index
            ilBody.MarkLabel(start); //defino el comienzo del for
            ilBody.Emit(OpCodes.Ldarg_0); //meto el this
            ilBody.Emit(OpCodes.Ldfld, index); //meto la i del for

            //meto en el campo this.toBuilder
            ilBody.Emit(OpCodes.Ldarg_0); //meto el this
            ilBody.Emit(OpCodes.Ldfld, toBuilder); //meto el to del for
            ilBody.Emit(OpCodes.Bgt, end); //si i > to se acabo el for
            level.Add(forParent);

            //genero el codigo del body
            Type bodyType = Body.GenCode(ilBody, forClass, field, level, end);

            level.RemoveAt(level.Count - 1);

            ilBody.Emit(OpCodes.Ldarg_0);
            ilBody.Emit(OpCodes.Ldfld, field);
            ilBody.Emit(OpCodes.Ldc_I4_1);
            ilBody.Emit(OpCodes.Beq, end);

            //actualizo this.index
            ilBody.Emit(OpCodes.Ldarg_0); //meto el this
            ilBody.Emit(OpCodes.Ldarg_0); //meto el this
            ilBody.Emit(OpCodes.Ldfld, index); //busco el valor de this.i y lo dejo en el tope
            ilBody.Emit(OpCodes.Ldc_I4_1); //meto el 1

            ilBody.Emit(OpCodes.Add); //i + 1
            ilBody.Emit(OpCodes.Stfld, index); //i = i + 1 (uso el replace estatico porque lo que tengo en el tope es un valor y no una referencia)
            ilBody.Emit(OpCodes.Br, start); //comienza de nuevo el for

            ilBody.MarkLabel(end); //final 

            ilBody.Emit(OpCodes.Ret); //se acabo el metodo del body del for

            forClass.CreateType(); //creo el tipo de la clase for

            // Crear una instancia del tipo que representa al for.
            ilGenerator.Emit(OpCodes.Ldarg_0);
            Asig.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel);
            To.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel);
            ilGenerator.Emit(OpCodes.Newobj, forConstructor);

            // Llamar al método que representa el cuerpo del for.
            ilGenerator.Emit(OpCodes.Callvirt, bodyBuilder);
            return null; //el for no retorna valor
        }
    }
}
