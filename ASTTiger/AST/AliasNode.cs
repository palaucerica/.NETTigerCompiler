using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class AliasDecNode : TypeDeclarationNode
    {
        public string Value_redef { get; private set;}
        public AliasDecNode(string value_redef) 
        {
            Value_redef = value_redef;
        }
    }
}
