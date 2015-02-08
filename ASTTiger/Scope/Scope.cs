using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class Scope
    {
        public Dictionary<string, Var_Scope> Vars //Variables declaradas        
        { get; private set; }

        public Dictionary<string, TypeReturn> Types //tipos declarados 
        { get; private set; }

        public Dictionary<string, Fun_Scope> Funcs //funciones declaradas
        { get; private set; }

        public Scope() 
        {
            Vars = new Dictionary<string, Var_Scope>();
            Types = new Dictionary<string, TypeReturn>();
            Funcs = new Dictionary<string, Fun_Scope>();

        }
        public Scope(Dictionary<string, Var_Scope> vars, Dictionary<string, TypeReturn> types, Dictionary<string, Fun_Scope> funcs)
        {
            Vars = vars;
            Types = types;
            Funcs = funcs;
        }
    }
}
