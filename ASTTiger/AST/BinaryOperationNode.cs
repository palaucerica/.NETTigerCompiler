using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class BinaryOperationNode : AritmeticNode
    {
        public LanguageNode Left { get; private set;}
        public LanguageNode Right { get; private set; }

        public BinaryOperationNode(LanguageNode left, LanguageNode right) 
        {
            Left = left;
            Right = right;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn t = Left.CheckSemantics(scope_list, errors);

            if (!(t is ReturnInt))//Mira si la parte izquierda no es Entera            
                errors.Add(new Error(line, column, "La expresión izquierda de la operación binaria debe ser entera"));

            t = Right.CheckSemantics(scope_list, errors);
            if (!(t is ReturnInt))//Mira si la parte derecha es Entera  
                errors.Add(new Error(line, column, "La expresión derecha de la operación binaria debe ser entera"));

            return new ReturnInt();
        }
    }
}
