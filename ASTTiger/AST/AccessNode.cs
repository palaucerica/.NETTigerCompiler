using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class AccessNode : ControlNode
    {
        public List<Access> Access_list { get; private set; }
        public LanguageNode Value { get; private set; }
        public List<TypeReturn> typesList = new List<TypeReturn>();
        
        public AccessNode(LanguageNode value, List<Access> access_list) 
        {
            Access_list = access_list;
            Value = value;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn typeOfValue = Value.CheckSemantics(scope_list, errors);
            TypeReturn actual = typeOfValue;
            bool found;
            foreach (var access in Access_list)
            {
                found = false;
                if (access is AccessPto) //pregunto si es un acceso a un record
                {
                    AccessPto aux = access as AccessPto;
                    if (actual is ReturnRecord)
                    {
                        ReturnRecord temp = actual as ReturnRecord;
                        typesList.Add(temp); //anado el record a mi lista de record
                        //ver si el record tiene el campo .id
                        foreach (var field in temp.Fields)
                        {
                            if (field.Item1.Equals(aux.Name)) //busco el campo igual al .id
                            {
                                actual = field.Item2; //guardo el tipo ese campo para la proxima iteracion
                                found = true;
                                break;
                            }
                        }
                        if (!found) //si no encontro el campo 
                            errors.Add(new Error(access.Line, access.Column, "El record no tiene ningun campo llamado " + aux.Name));
                    }
                    else //si el tipo al que se quiere hacer el  .   no es un record
                        errors.Add(new Error(access.Line, access.Column, "El tipo no es un record"));
                }
                else
                {
                    //es un acceso a un array
                    AccessIndex aux = access as AccessIndex;
                    if (actual is ReturnArray)
                    {
                        TypeReturn typeOfIndex = aux.Arg.CheckSemantics(scope_list, errors); //hago el chequeo semantico a [exp]
                        if (!(typeOfIndex is ReturnInt)) //pregunto si es entera
                            errors.Add(new Error(access.Line, access.Column, "La expresion de indexer debe devolver un entero"));
                        ReturnArray temp = actual as ReturnArray;
                        typesList.Add(temp);
                        actual = temp.Type_Of_Elements; //el tipo del acceso es el mismo para todo los elementos del array
                    }
                    else
                        errors.Add(new Error(access.Line, access.Column, "El tipo que se desea indexar no es un array"));
                }
            }
            return actual;
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            //genero el codigo del Lvalue (en el tope queda una referencia al objeto)
            Type valueType = Value.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel); 
            for (int i = 0; i < Access_list.Count; i++)
            {
                if (Access_list[i] is AccessPto)
                {
                    //es un acceso a un record
                    //dejo en el tope la referencia al campo 
                    ilGenerator.Emit(OpCodes.Ldfld, (typesList[i] as ReturnRecord).FieldsBuilds[(Access_list[i] as AccessPto).Name]);
                    if (i == Access_list.Count - 1)
                        return (typesList[i] as ReturnRecord).Fields.Where(x => x.Item1.Equals((Access_list[i] as AccessPto).Name)).First().Item2.MyType(); //devuelvo el tipo del record
                }
                else
                {
                    //es un acceso a un array
                    //genero el codigo de la expresion del index del array (deja en el tope el valor del indice)
                    Type indexType = (Access_list[i] as AccessIndex).Arg.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel);
                    //meto array[index] en el tope de la pila
                    ilGenerator.Emit(OpCodes.Ldelem, (typesList[i] as ReturnArray).Type_Of_Elements.MyType()); //me hace falta saber el tipo de los elementos del array
                    if (i == Access_list.Count - 1)
                        return (typesList[i] as ReturnArray).Type_Of_Elements.MyType();
                }
            }
            return valueType;
        }

        public bool GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel, ref FieldBuilder last, ref Type type)
        {
            type = null;
            //genero el codigo del Lvalue (en el tope queda una referencia al objeto)
            Type valueType = Value.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel);
            for (int i = 0; i < Access_list.Count; i++)
            {
                if (Access_list[i] is AccessPto)
                {
                    //es un acceso a un record
                    //dejo en el tope la referencia al campo 
                    
                    if (i == Access_list.Count - 1)
                    {
                        last = (typesList[i] as ReturnRecord).FieldsBuilds[(Access_list[i] as AccessPto).Name];
                        return true;
                    }
                    else
                        ilGenerator.Emit(OpCodes.Ldfld, (typesList[i] as ReturnRecord).FieldsBuilds[(Access_list[i] as AccessPto).Name]);
                }
                else
                {
                    //es un acceso a un array
                    //genero el codigo de la expresion del index del array (deja en el tope el valor del indice)
                    Type indexType = (Access_list[i] as AccessIndex).Arg.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel);
                    //meto array[index] en el tope de la pila
                    if (i == Access_list.Count - 1)
                    {
                        last = null;
                        type = (typesList[i] as ReturnArray).Type_Of_Elements.MyType();
                        return false;
                    }
                    else
                        ilGenerator.Emit(OpCodes.Ldelem, (typesList[i] as ReturnArray).Type_Of_Elements.MyType()); //me hace falta saber el tipo de los elementos del array

                }
            }
            last = null;
            return true;
        }
    }
}
