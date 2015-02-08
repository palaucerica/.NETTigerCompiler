using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class ArrayCreate : ControlNode
    {
        public LanguageNode Size { get; private set; }
        public LanguageNode Initial { get; private set; }
        public string Name { get; private set; }
        ReturnArray Array;
        
        public ArrayCreate(string name, LanguageNode size, LanguageNode initial) 
        {
            Name = name;
            Size = size;
            Initial = initial;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            //chequeamos si el tipo del array ya se definio anteriormente
            TypeReturn typeOfArray = Utils.FindType(scope_list, Name);
            if (typeOfArray == null)
                errors.Add(new Error(line, column, "El tipo " + this.Name + "no se ha delcarado todavia"));

            //verificamos que la expresion de inicializacion devuelva algun valor(puede ser nil)
            TypeReturn typeOfInitial = Initial.CheckSemantics(scope_list, errors);

            if (typeOfInitial is ReturnNotValue || typeOfInitial == null) //pregunto por null porque si hubo un error devuelvo null
                errors.Add(new Error(line, column, "La expresion de la inicializacion del array debe devolver algun valor"));

            if (!(typeOfArray is ReturnArray)) //el tipo no es un array            
                errors.Add(new Error(line, column, "El tipo " + "'" + this.Name + "'" + " no es de tipo array"));

            else
            {
                if (typeOfInitial is ReturnNil) //si es nil no pueden ser int los valores del array
                {
                    if ((typeOfArray as ReturnArray).Type_Of_Elements is ReturnInt)
                        errors.Add(new Error(line, column, "El array no permite 'nil' porque los valores del array son 'int'"));
                }
                else if (((ReturnArray)typeOfArray).Type_Of_Elements.ToString() != typeOfInitial.ToString())
                    errors.Add(new Error(line, column, "Los elementos del array son de tipo '" + ((ReturnArray)typeOfArray).Type_Of_Elements.ToString() + "' y no de tipo '" + typeOfInitial.ToString() + "'"));
            }

            //verificamos que el size es un entero
            TypeReturn typeOfSize = Size.CheckSemantics(scope_list, errors);
            if (!(typeOfSize is ReturnInt))
                errors.Add(new Error(line, column, "La expresion del tamaño del array no devuelve un entero"));
            Array = typeOfArray as ReturnArray; //para usarlo en la generacion de codigo
            return (typeOfArray != null) ? typeOfArray : new ReturnArray(this.Name, typeOfInitial); //retorno el array 
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            Label begin = ilGenerator.DefineLabel();
            Label end = ilGenerator.DefineLabel();
            
            Type typeInitial = Initial.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel); //genero el codigo del tipo de los elementos del array
            LocalBuilder value = ilGenerator.DeclareLocal(typeInitial);
            ilGenerator.Emit(OpCodes.Stloc, value); //guardo la variable que tiene el valor de los elementos del array

            Type typeSize = Size.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel); //genero el codigo del size y deja en el tope el tamano
            LocalBuilder size = ilGenerator.DeclareLocal(typeof(int));
            ilGenerator.Emit(OpCodes.Stloc, size); //guardo el size del array
            ilGenerator.Emit(OpCodes.Ldloc, size); //lo meto en el tope porque la creacion del array necesita el tamano en el tope
            ilGenerator.Emit(OpCodes.Newarr, typeInitial); //el size esta en el tope

            //ahora tengo que crear la variable del array y guardarla
            LocalBuilder array = ilGenerator.DeclareLocal(typeInitial);
            ilGenerator.Emit(OpCodes.Stloc, array); //guardo el array

            //ahora tengo que empezar a llenarlo
            LocalBuilder index = ilGenerator.DeclareLocal(typeof(int)); //el indice por el que me voy moviendo
            ilGenerator.Emit(OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Stloc, index); //hago index=0
            //comienza el ciclo
            ilGenerator.MarkLabel(begin); 
            //ver si no me he pasado
            ilGenerator.Emit(OpCodes.Ldloc, index);
            ilGenerator.Emit(OpCodes.Ldloc, size);
            ilGenerator.Emit(OpCodes.Bge, end); //si index >= size se acabo el ciclo
            //ahora si lleno (se usa el stelem)
            ilGenerator.Emit(OpCodes.Ldloc, array); //meto el array
            ilGenerator.Emit(OpCodes.Ldloc, index); //meto el indice por el que voy
            ilGenerator.Emit(OpCodes.Ldloc, value); //meto la variable que tiene el valor con el que se va a llenar
            ilGenerator.Emit(OpCodes.Stelem, typeInitial); 
            //aumento el indice
            ilGenerator.Emit(OpCodes.Ldc_I4_1);
            ilGenerator.Emit(OpCodes.Ldloc, index);
            ilGenerator.Emit(OpCodes.Add); //sumo index + 1
            ilGenerator.Emit(OpCodes.Stloc, index); //hago index = index + 1
            ilGenerator.Emit(OpCodes.Br, begin); //comienza otra iteracion

            //se acabo el ciclo
            ilGenerator.MarkLabel(end);

            //ilGenerator.Emit(OpCodes.Ldarg); 
            ilGenerator.Emit(OpCodes.Ldloc, array); //dejo la referencia al array en el tope

            return Array.MyType();
        }
    }
}
