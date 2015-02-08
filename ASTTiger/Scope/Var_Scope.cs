using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class Var_Scope
    {
        public string Name { get; private set; }
        public TypeReturn Var_type { get; private set; }
        public bool NoAsign { get; private set; }
        public FieldBuilder VarbBuilder { get;set; }

        public Var_Scope(string name, TypeReturn type)
        {
            Name = name;
            Var_type = type;
            NoAsign = false;
        }

        public Var_Scope(string name, TypeReturn type, bool noAsign )
        {
            Name = name;
            Var_type = type;
            NoAsign = noAsign;
        }
    }
}
