using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class DeclarationNode : LanguageNode
    {
        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            throw new NotImplementedException();
        }      
    }
}
