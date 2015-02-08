using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public abstract class RelationalNode : OperationNode
    {
        public LanguageNode Left { get; private set;}
        public LanguageNode Right { get; private set; }

        public RelationalNode(LanguageNode left, LanguageNode right) 
        {
            Left = left;
            Right = right;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn t = Left.CheckSemantics(scope_list, errors);

            if (!(t is ReturnInt || t is ReturnString || t is ReturnNil))//Mira si la parte izquierda es valida(solo pueden ser entera o string)             
                errors.Add(new Error(line, column, "La expresión izquierda de la operación relacional debe ser 'int' o 'string'"));                      

            TypeReturn t1 = Right.CheckSemantics(scope_list, errors);

            if (!(t1 is ReturnInt || t1 is ReturnString || t1 is ReturnNil))//Mira si la parte derecha es valida(solo pueden ser entera o string)             
                errors.Add(new Error(line, column, "La expresión derecha de la operación relacional debe ser 'int' o 'string'"));

            if (t1 == null || t == null || t1.ToString() != t.ToString())
            {
                if ((t is ReturnInt && t1 is ReturnNil) || (t is ReturnNil && t1 is ReturnInt) || (t is ReturnNil && t1 is ReturnNil))
                    errors.Add(new Error(line, column, "Las expresiones comparadas son invalidas"));
                else
                    if (!(t is ReturnNil) && !(t1 is ReturnNil))
                    errors.Add(new Error(line, column, "Ambas expresiones deben ser de tipo 'int' o de tipo 'string'"));
            }
            return new ReturnInt();
        }

        protected TypeReturn CheckSemanticsForEqualAndDistinct(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn tLeft = Left.CheckSemantics(scope_list, errors);
            TypeReturn tRight = Right.CheckSemantics(scope_list, errors);

            if (tLeft == null || tRight == null) //si alguna de las dos variables tuvo problemas no se hace la comparacion
                return new ReturnInt();

            if (tLeft is ReturnNotValue || tRight is ReturnNotValue)
                errors.Add(new Error(line, column, "De las expresiones comparadas hay al menos una que no tiene valor"));

            if (tLeft is ReturnInt && !(tRight is ReturnInt))
                errors.Add(new Error(line, column, "Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo 'int' con una del tipo '" + tRight.ToString() + "'"));

            if (tLeft is ReturnString && !(tRight is ReturnString || tRight is ReturnNil))
                errors.Add(new Error(line, column, "Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo 'string' con una del tipo '" + tRight.ToString() + "'"));

            if (tLeft is ReturnArray && !(tRight is ReturnNil || tLeft.Equals(tRight)))
                errors.Add(new Error(line, column, "Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo '" + tLeft.ToString() + "' con una del tipo '" + tRight.ToString() + "'"));

            if (tLeft is ReturnRecord && !(tRight is ReturnNil || tLeft.Equals(tRight)))
                errors.Add(new Error(line, column, "Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo '" + tLeft.ToString() + "' con una del tipo '" + tRight.ToString() + "'"));

            if (tLeft is ReturnNil && ((tRight is ReturnInt) || (tRight is ReturnNil)))
                errors.Add(new Error(line, column, "Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo Nil con una del tipo " + tRight.ToString() + "'"));

            return new ReturnInt();
        }
    }
}
