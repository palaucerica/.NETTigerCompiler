using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class RecordCreate : ControlNode
    {
        public List<Tuple<string, LanguageNode>> Dict { get; private set; }
        public string Name { get; private set; }
        ReturnRecord record;
        public RecordCreate(string name, List<Tuple<string, LanguageNode>> dict)
        {
            Name = name;
            Dict = dict;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            ReturnRecord recordDeclared = null;
            //chequear si el tipo del record ya existe en el scope
            KeyValuePair<string, TypeReturn> pair = default(KeyValuePair<string, TypeReturn>);

            for (int i = 0; i < scope_list.Count; i++)
            {
                Scope scope = scope_list[i];
                pair = scope.Types.FirstOrDefault(s => s.Key.Equals(this.Name)); //busco el tipo (nombre) del record en el scope

                if (!pair.Equals(default(KeyValuePair<string, TypeReturn>))) //pregunto si existe el nombre del tipo en este ambito
                {
                    //chequeo si el tipo es un record
                    if (pair.Value is ReturnRecord)
                        recordDeclared = pair.Value as ReturnRecord;
                    else
                        errors.Add(new Error(line, column, "El tipo '" + Name + "' no es de tipo record"));
                    break;
                }
            }

            if (pair.Equals(default(KeyValuePair<string, TypeReturn>))) //pregunto si se encontro el el tipo del record en el scope
            {
                errors.Add(new Error(line, column, "El tipo '" + Name + "' no existe en este ambito"));
                return null; //el record no esta declarado en este scope
            }

            //el menor de la cantidad de campos entre el instanciado y el declarado para no irme de rango en el for
            int min = Math.Min(recordDeclared.Fields.Count, Dict.Count);

            //chequear que concuerden los nombres de los campos y sus tipos de retorno (entre el record declarado y el instanciado)
            for (int i = 0; i < min; i++) //por cada campo
            {
                //chequeo que los nombres sean los mismos
                string keyRecordInstanced = Dict.ElementAt(i).Item1; //cojo el nombre del campo i-esimo del record instanciado
                string keyRecordDeclared = recordDeclared.Fields.ElementAt(i).Item1; //el nombre del campo i-esimo del record declarado
                if (!keyRecordInstanced.Equals(keyRecordDeclared)) //pregunto si los nombres de los campos son distintos
                    errors.Add(new Error(line, column, "El " + i + "-esimo campo no se llama " + keyRecordDeclared + " sino " + keyRecordInstanced));

                //chequeo que los tipos de los campos sean los mismos
                TypeReturn typeOfParameterDeclared = recordDeclared.Fields.ElementAt(i).Item2; //el tipo del campo i-esimo del record declarado
                if(typeOfParameterDeclared == null) //si es null es porque no se encontro el tipo en este ambito
                    errors.Add(new Error(line, column, "El tipo '" + recordDeclared.Fields.ElementAt(i).Item2 + "' no se encuentra declarado en este ambito"));
               
                
                TypeReturn typeOfParameterInstanced = Dict.ElementAt(i).Item2.CheckSemantics(scope_list, errors); //el tipo del campo i-esimo cuando se instancio el record
               
                if (typeOfParameterInstanced is ReturnNil)  //chequeo si el campo del record instanciado es nil
                {
                    //hay que chequear que el tipo del parametro no sea ni int ni string
                    if (typeOfParameterDeclared is ReturnInt)                    
                        errors.Add(new Error(line, column, "Solo se puede asignar nil a un tipo record, array o string"));                    
                }
                //pregunto si los TypeReturn de los campos son != de null para que no me de NullException al pedirle el GetType()
                else if (typeOfParameterDeclared != null && typeOfParameterInstanced != null &&  !typeOfParameterDeclared.GetType().Equals(typeOfParameterInstanced.GetType())) //pregunto si los tipos de retorno son iguales
                    errors.Add(new Error(line, column, "El record '" + recordDeclared.Record_name + "'. El tipo del campo '" + keyRecordDeclared + "' es '" + typeOfParameterDeclared.ToString() + "' y no '" + typeOfParameterInstanced.ToString()+"'"));
            }

            if (Dict.Count != recordDeclared.Fields.Count) //para saber si los records tienen la misma cantidad de campos
                errors.Add(new Error(line, column, "El record '" + Name + "' no tiene " + Dict.Count + " campos"));
            
            record = recordDeclared;
            return recordDeclared; //retorno el mismo record que estaba en el scope
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            foreach (var item in Dict) //por cada campo del record
            {
                item.Item2.GenCode(ilGenerator, parent, IsBreakFields,level, endLabel); //genero codigo (lo mete en la pila)
            }
            ilGenerator.Emit(OpCodes.Newobj, this.record.constructor); //creo una nueva instancia con el constructor de la clase de este tipo
            //el Newobj deja en el tope de la pila una referencia al nuevo objeto

            return record.MyType(); //devuelvo el tipo del record
        }
    }
}
