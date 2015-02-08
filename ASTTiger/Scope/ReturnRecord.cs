using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class ReturnRecord : TypeReturn
    {
        //poner el constructor builder
        public ConstructorBuilder constructor { get; set; } //el constructor de la clase para crear instancias de este record

        public string Record_name { get; private set; } //contiene el nombre del record, es para las comparaciones

        public TypeBuilder TypeOfRecord { get; set; } //este campo se llena en alguna parte

        public List<Tuple<string, TypeReturn>> Fields { get; private set; } //contiene el nombre del campo y el tipo de retorno

        public Dictionary<string, FieldBuilder> FieldsBuilds { get; set; } //los fieldBuilder de los records

        public ReturnRecord(string record_name, List<Tuple<string, TypeReturn>> values)
        {
            this.Record_name = record_name;
            this.Fields = values;
            FieldsBuilds = new Dictionary<string, FieldBuilder>();
        }

        public override bool Equals(object obj)
        {
            ReturnRecord r = obj as ReturnRecord;
            if (r == null || r.Record_name != Record_name) return false;

            return true;
        }

        public override string ToString()
        {
            return Record_name;
        }

        public override Type MyType()
        {
            return TypeOfRecord;
        }
    }
}
