using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class WhileNode : ControlNode
    {
        public LanguageNode Condi { get; private set; }
        public LanguageNode Body { get; private set; }
        public WhileNode(LanguageNode condi, LanguageNode body)
        {
            Condi = condi;
            Body = body;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            countOfClicles++;
            TypeReturn typeOfCondi = Condi.CheckSemantics(scope_list, errors);
            if (!(typeOfCondi is ReturnInt))  //La expresion de la condicional del if tiene que devolver un entero
                errors.Add(new Error(line, column, "La condicion del while debe retornar un entero"));

            TypeReturn typeOfBody = Body.CheckSemantics(scope_list, errors);
            if (!(typeOfBody is ReturnNotValue))
                errors.Add(new Error(line, column, "La expresion del body del while no debe retornar ningun valor"));

            countOfClicles--;
            return new ReturnNotValue();
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            Label beginWhile = ilGenerator.DefineLabel();
            Label endWhile = ilGenerator.DefineLabel();

            ilGenerator.MarkLabel(beginWhile); //inicio del while
            Type condiType = Condi.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel); //genero el codigo de la condicion (deja en el tope el valor de la condicion)
            ilGenerator.Emit(OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Beq, endWhile); //si la condicion es menor o igual que 0

            Type boydType = Body.GenCode(ilGenerator, parent, IsBreakFields, level, endWhile); //genero el codigo del body
            
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldfld, IsBreakFields);
            ilGenerator.Emit(OpCodes.Ldc_I4_1);
            ilGenerator.Emit(OpCodes.Beq, endWhile);

            ilGenerator.Emit(OpCodes.Br, beginWhile); //vuelve al principio del while

            ilGenerator.MarkLabel(endWhile); // se acabo el while
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Stfld, IsBreakFields); //pongo el break en true

            return null;
        }
    }
}
