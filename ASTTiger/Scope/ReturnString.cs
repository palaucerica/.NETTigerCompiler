using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class ReturnString : TypeReturn
    {
        public override string ToString()
        {
            return "string";
        }

        public override Type MyType()
        {
            return typeof(string);
        }

        public override bool Equals(object obj)
        {
            return obj is ReturnString;
        }
    }
}
