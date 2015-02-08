using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class ReturnNotValue : TypeReturn
    {
        public override string ToString()
        {
            return "No valor";
        }

        public override Type MyType()
        {
            return typeof(void);
        }
    }
}
