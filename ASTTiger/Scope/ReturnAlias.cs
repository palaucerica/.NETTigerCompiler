using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class ReturnAlias : TypeReturn
    {
        public string Name_Alias { get; private set; }

        public string Type_redefine { get; private set; }

        public ReturnAlias(string name_alias, string type_redefine)
        {
            this.Name_Alias = name_alias;
            this.Type_redefine = type_redefine;
        }

        public override Type MyType()
        {
            throw new NotImplementedException();
        }
    }
}
