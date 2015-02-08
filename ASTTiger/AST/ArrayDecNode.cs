using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class ArrayDecNode : TypeDeclarationNode
    {
        public string Value { get; private set;}
        public ArrayDecNode(string value) 
        {
            Value = value;
        }
    }
}
