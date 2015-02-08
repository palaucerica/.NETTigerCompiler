using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class AndNode : LogicalNode
    {
        public AndNode(LanguageNode left, LanguageNode right):base(left,right)
        {           
        }
        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            //Declaro las etiquetas
            Label fal = ilGenerator.DefineLabel();
            Label fin = ilGenerator.DefineLabel();

            //genero codigo del izquierdo
            Type l = Left.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);

            //meto cero en la pila
            ilGenerator.Emit(OpCodes.Ldc_I4_0);

            //veo si es falso y salto
            ilGenerator.Emit(OpCodes.Beq, fal);

            //genero codigo del derecho y lo dejo en la pila
            Type r = Right.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);

            //salto pa fin
            ilGenerator.Emit(OpCodes.Br, fin);

            //pongo la etiqueta falso
            ilGenerator.MarkLabel(fal);

            //meto cero en la pila
            ilGenerator.Emit(OpCodes.Ldc_I4_0);

            //pongo la etiqueta fin
            ilGenerator.MarkLabel(fin);

            return l;
        }
    }
}
