using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class LessThanEqualsNode : RelationalNode
    {
        public LessThanEqualsNode(LanguageNode left, LanguageNode right): base(left, right)
        {           
        }
        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            //Genero codigo y lo dejo en la pila
            Type l = Left.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);
            Type r = Right.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);

            //Declaro las etiquetas
            Label verd = ilGenerator.DefineLabel();
            Label fin = ilGenerator.DefineLabel();

            //El caso de que sea un "string"
            if (l == typeof(string) || r  == typeof(string))
            {
                //Compara los 2 string. Mete en la pila 0 si son iguales,< 0 si l<r, >0 si l>r 
                ilGenerator.Emit(OpCodes.Call, typeof(String).GetMethod("Compare", new Type[] { typeof(String), typeof(String) }));

                ilGenerator.Emit(OpCodes.Ldc_I4_0);
            }

            //Siempre no importa lo que sea
            ilGenerator.Emit(OpCodes.Ble, verd);

            //Es false y salto pa fin
            ilGenerator.Emit(OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Br, fin);

            //Marco que fue verdadero
            ilGenerator.MarkLabel(verd);
            ilGenerator.Emit(OpCodes.Ldc_I4_1);

            ilGenerator.MarkLabel(fin);

            return typeof(int);
        }
    }
}
