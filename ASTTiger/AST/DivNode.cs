using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class DivNode : BinaryOperationNode
    {
        public DivNode(LanguageNode left, LanguageNode right): base(left, right)
        {           
        }
        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            Type l = Left.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);//genero codigo del "left" y lo mete en la pila
            Type r = Right.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);//genero codigo del "right" y lo mete en la pila
            ilGenerator.Emit(OpCodes.Div);//divido l/r y lo pone en el tope de la pila

            return l;
        }
    }
}
