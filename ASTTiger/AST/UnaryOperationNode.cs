using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class UnaryOperationNode : AritmeticNode
    {
        public LanguageNode Value { get; private set;}
        public UnaryOperationNode(LanguageNode value) 
        {
            Value = value;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn t = Value.CheckSemantics(scope_list, errors);

            if (!(t is ReturnInt))//Mira a ver si el Value es entero           
                errors.Add(new Error(line, column, "La expresión debe ser entera"));

            return new ReturnInt();
        }
    }
}
