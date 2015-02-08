using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class OrNode : LogicalNode
    {
        public OrNode(LanguageNode left, LanguageNode right)
            : base(left, right)
        {
        }
        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            //creo las etiquetas
            Label verd = ilGenerator.DefineLabel(); 
            Label fin = ilGenerator.DefineLabel();

            //genero codigo del "left" y lo mete en la pila
            Type l = Left.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);

            //esto es para ver si el miembro izquierdo es distinto de cero
            ilGenerator.Emit(OpCodes.Ldc_I4_0);

            //compara los 2 primeros de la pila y guarda 1 si son iguales sino guarda 0
            ilGenerator.Emit(OpCodes.Ceq);

            ilGenerator.Emit(OpCodes.Ldc_I4_0);

            //salta si el miembro izquierdo es true
            ilGenerator.Emit(OpCodes.Beq, verd);

            //genero codigo del "right" y lo mete en la pila 
            Type r = Right.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);

            //salto incondicional(salta para el fin)
            ilGenerator.Emit(OpCodes.Br, fin);

            //marco la etiqueta verdadera
            ilGenerator.MarkLabel(verd);

            //mete el valor "1" en la pila ya que es verdadera
            ilGenerator.Emit(OpCodes.Ldc_I4_1);

            //marco la etiqueta fin
            ilGenerator.MarkLabel(fin);           

            return l;
        }
    }
}
