using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public abstract class LanguageNode
    {
        public int line; //linea del error
        public int column; //columna del error

        public abstract TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors);

        public virtual Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel) { return null; }
       
    }
}
