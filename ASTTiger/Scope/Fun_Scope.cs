using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class Fun_Scope
    {
        public List<Tuple<string, TypeReturn>> Param { get; private set; }
        public string Name { get; private set; }
        public TypeReturn Retu { get; private set; }
        public ConstructorBuilder constr;
        public MethodBuilder meth;
        public bool IsSystem;

        public Fun_Scope(string name, List<Tuple<string, TypeReturn>> param, TypeReturn retu) 
        {
            Param = param;
            Name = name;
            Retu = retu;
        }

        public Fun_Scope(string name, List<Tuple<string, TypeReturn>> param, TypeReturn retu,bool isSystem)
        {
            Param = param;
            Name = name;
            Retu = retu;
            IsSystem = isSystem;
        }
    }
}
