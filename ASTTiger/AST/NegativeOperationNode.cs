using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class NegativeOperationNode : UnaryOperationNode
    {
        public NegativeOperationNode(LanguageNode value): base(value)
        {           
        }
        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            Type t = Value.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel);//Genera codigo y mete en la pila el resultado
            ilGenerator.Emit(OpCodes.Neg);//Coge lo que está en el tope de la pila ,lo saca y lo niega y lo mete denuevo
            return t;           
        }
    }
}
