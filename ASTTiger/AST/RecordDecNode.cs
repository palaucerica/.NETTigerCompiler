using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace ASTTiger
{
    public class RecordDecNode : TypeDeclarationNode
    {
        public List<Tuple<string, string>> Value { get; private set; } //lista de pares id,tipo
        public ReturnRecord record;
        public RecordDecNode(List<Tuple<string, string>> value)
        {
            Value = value;
        }

        public void CreateType()
        {
            TypeBuilder typeClass = Utils.module.DefineType(Id + Utils.AutoNumeric, TypeAttributes.Public | TypeAttributes.Class);
            record.TypeOfRecord = typeClass;
        }

        public Type GenCode()
        {
            ConstructorBuilder constructor = record.TypeOfRecord.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, record.Fields.Select(a => a.Item2.MyType()).ToArray());
            ILGenerator ctor1IL = constructor.GetILGenerator();
            record.constructor = constructor; //para poder saber que clase tengo que instanciar
            for (int i = 1; i <= record.Fields.Count; i++)
            {
                //guardar los fieldBuilder de los campos en el return record para usarlos en el accessNode
                FieldBuilder field = record.TypeOfRecord.DefineField(record.Fields[i - 1].Item1, record.Fields[i - 1].Item2.MyType(), FieldAttributes.Public);
                record.FieldsBuilds[record.Fields[i - 1].Item1] = field; //guardo el FieldBuilder del campo 
                ctor1IL.Emit(OpCodes.Ldarg_0); //meto el this
                ctor1IL.Emit(OpCodes.Ldarg, i); //meto el argumento i-esimo a la pila
                ctor1IL.Emit(OpCodes.Stfld, field); //asigna el valor del argumento al campo field
            }
            ctor1IL.Emit(OpCodes.Ret);

            // Crear la clase para el record.
            record.TypeOfRecord.CreateType();

            return null;
        }
    }
}
