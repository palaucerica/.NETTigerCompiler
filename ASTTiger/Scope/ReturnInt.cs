using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class ReturnInt : TypeReturn
    {
        public override string ToString()
        {
            return "int";
        }

        public override Type MyType()
        {
            return typeof(int);
        }

        public override bool Equals(object obj)
        {
            return obj is ReturnInt;
        }
    }
}
