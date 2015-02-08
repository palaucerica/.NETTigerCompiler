using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class ReturnNil : TypeReturn
    {
        public override string ToString()
        {
            return "nil";
        }

        public override Type MyType()
        {
            return typeof(object);
        }
    }
}
