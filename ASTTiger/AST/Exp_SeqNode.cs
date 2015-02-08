using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class ExpSeqNode : ControlNode
    {
        public List<LanguageNode> Expre { get; private set; }
        TypeReturn TypeExpSeq;
        public ExpSeqNode(List<LanguageNode> expre) 
        {
            Expre = expre;
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            if (Expre.Count > 0)
            {
                Type expType;
                for (int i = 0; i < Expre.Count - 1; i++) //por cada expresion genera codigo
                {
                    //si alguna intermendia devuelve valor sacarla de la pila
                    //dejar solo en la pila la ultima expresion
                    expType = Expre[i].GenCode(ilGenerator, parent, IsBreakFields,level, endLabel);
                    if (expType != null && expType!= typeof(void))
                    {
                        LocalBuilder local = ilGenerator.DeclareLocal(expType);
                        //saco de la pila lo que esta en el tope
                        ilGenerator.Emit(OpCodes.Stloc, local);
                    }
                    ////FALTA VER SI DEVUELVE BREAK ALGUNA EXPRESION
                    if (TypeExpSeq is ReturnBreak)
                    {
                        ilGenerator.Emit(OpCodes.Ldarg_0);
                        ilGenerator.Emit(OpCodes.Ldfld, IsBreakFields);
                        ilGenerator.Emit(OpCodes.Ldc_I4_1);
                        ilGenerator.Emit(OpCodes.Beq, endLabel);
                    }
                }
                //el ultimo no lo saco de la pila
                expType = Expre[Expre.Count - 1].GenCode(ilGenerator, parent, IsBreakFields,level, endLabel); //genero el codigo de la ultima expresion
                if (TypeExpSeq is ReturnBreak)
                {
                    if (expType != null && expType != typeof(void))
                    {
                        LocalBuilder local = ilGenerator.DeclareLocal(expType);
                        //saco de la pila lo que esta en el tope
                        ilGenerator.Emit(OpCodes.Stloc, local);
                    }
                }
                return TypeExpSeq.MyType();            
            }
            return null; //no hay ninguna expresion en el exp-sec
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            if (Expre.Count > 0)
            {
                bool foundBreak = false;
                for (int i = 0; i < Expre.Count; i++)
                {
                    TypeReturn typeOfExp = Expre[i].CheckSemantics(scope_list, errors); //hago el chequeo semantico a la expresion de turno
                    //si la expresion retorno por un break => el exp-sec no retorna valor
                    if (typeOfExp is ReturnBreak) foundBreak = true; //no retorno aqui para hacerle el chequeo semantico a cada expresion del exp-sec
                    if (i == Expre.Count - 1)
                    {
                        TypeExpSeq = foundBreak ? new ReturnBreak() : typeOfExp; //si se encontro un break retorno break para poderlo cogerlo en otro exp-sec, si no retorno el tipo de la ultima expresion
                        return TypeExpSeq;
                    }
                }
                return null;
            }
            else
            {
                TypeExpSeq = new ReturnNotValue(); //si no hay expresiones no se retorna valor
                return TypeExpSeq;
            }
        }
    }
}
