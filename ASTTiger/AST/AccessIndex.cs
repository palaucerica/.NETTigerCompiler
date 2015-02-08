using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class AccessIndex : Access
    {
        public LanguageNode Arg { get; private set; }
       
        public AccessIndex(LanguageNode arg, int line, int column)
        {
            Arg = arg;
            Column = column;
            Line = line;
        }

    }
}
