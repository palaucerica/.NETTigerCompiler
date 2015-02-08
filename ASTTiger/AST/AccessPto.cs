using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class AccessPto : Access
    {
        public string Name { get; private set; }
       
        public AccessPto(string name ,int line,int column) 
        {
            Name = name;
            Column=column;
            Line = line;
        }
    }
}
