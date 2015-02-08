using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class EqualsNode : RelationalNode
    {
        public EqualsNode(LanguageNode left, LanguageNode right)
            : base(left, right)
        {

        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            return CheckSemanticsForEqualAndDistinct(scope_list, errors);
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            //Genero codigo y lo dejo en la pila
            Type l = Left.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);
            Type r = Right.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);

            //Declaro las etiquetas
            Label verd = ilGenerator.DefineLabel();
            Label fin = ilGenerator.DefineLabel();

            //El caso de que sea un String
            if (l == typeof(string) || r == typeof(string))
            {
                //Compara los 2 string. Mete en la pila 0 si son iguales,< 0 si l<r, >0 si l>r 
                ilGenerator.Emit(OpCodes.Call, typeof(String).GetMethod("Compare", new Type[] { typeof(String), typeof(String) }));

                ilGenerator.Emit(OpCodes.Ldc_I4_0);

            }
            //El caso de que sea un Record o un Array 
            else if (l != typeof(int))
            {
                //Compara los 2. Mete en la pila 0 si no son iguales y 1 si lo son 
                ilGenerator.Emit(OpCodes.Call, typeof(Object).GetMethod("Equals", new Type[] { typeof(Object), typeof(Object) }));
                ilGenerator.Emit(OpCodes.Ldc_I4_1);
            }

            ilGenerator.Emit(OpCodes.Beq, verd);

            //Va para la etiqueta fin ya que es falso
            ilGenerator.Emit(OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Br, fin);


            ilGenerator.MarkLabel(verd);
            ilGenerator.Emit(OpCodes.Ldc_I4_1);

            ilGenerator.MarkLabel(fin);


            return typeof(int);
        }
    }
}
