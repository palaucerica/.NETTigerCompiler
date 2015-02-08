using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class IntNode : AtomicNode
    {
        public int Value { get; private set;}
        public IntNode(string value) 
        {
            Value = int.Parse(value);
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            return new ReturnInt();
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            ilGenerator.Emit(OpCodes.Ldc_I4, Value);
            return typeof(int);
        }
    }
}
