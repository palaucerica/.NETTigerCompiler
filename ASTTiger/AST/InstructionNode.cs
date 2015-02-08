using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public abstract class InstructionNode : LanguageNode
    {
        public static int countOfClicles = 0;
    }
}
