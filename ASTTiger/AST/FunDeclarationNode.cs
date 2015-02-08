using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;


namespace ASTTiger
{
    public abstract class FunDeclarationNode : DeclarationNode
    {
        public LanguageNode Body { get; set; }
        public abstract bool CheckHeader(List<Scope> scope_list, List<Error> errors);//Chequear el encabezado de la función
        public abstract void CreateType(TypeBuilder parent);
        //public abstract void GenCode(TypeBuilder parent, List<FieldBuilder> level);
    }
}
