using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class IfThenElseNode : IfThenNode
    {
        public LanguageNode Body_else { get; private set; }
        public IfThenElseNode(LanguageNode cond, LanguageNode body, LanguageNode body_else): base(cond, body) 
        {
            Body_else = body_else;            
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            this.CheckCondition(scope_list, errors); //chequea que la expresion de la condicion sea un entero 

            //hago el chequeo semantico del then y del else
            TypeReturn typeOfBody = Body.CheckSemantics(scope_list, errors); 
            TypeReturn typeOfBodyElse = Body_else.CheckSemantics(scope_list, errors);

            if (typeOfBody == null || typeOfBodyElse == null) //pregunto si hubo problemas en el then y en el else
                return null;
            //chequeamos que los tipos devueltos por el then y el else sean iguales (puede ser nil uno de las exp mientras la otra no sea int)
            if (typeOfBody is ReturnNil)
            {
                if (typeOfBodyElse is ReturnInt)
                    errors.Add(new Error(line, column, "Los tipos retornados por las expresiones del then y del else tienen que ser iguales"));
                else
                    return typeOfBodyElse;
            }
            else
            {
                if (typeOfBodyElse is ReturnNil)
                {
                    if (typeOfBody is ReturnInt)
                        errors.Add(new Error(line, column, "Los tipos retornados por las expresiones del then y del else tienen que ser iguales"));
                    else
                        return typeOfBody;
                }

                else if (!typeOfBody.ToString().Equals(typeOfBodyElse.ToString())) //el tipo del then y el del else tienen que ser iguales
                    errors.Add(new Error(line, column, "Los tipos retornados por las expresiones del then y del else tienen que ser iguales"));
            }
            //tanto la exp del then como la del else retornan el mismo tipo => retorno el tipo de cualquiera de las dos
            return typeOfBody; //VER AQUI CUANDO LOS TIPOS SEAN != SI DEVUELVO NULL
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            Label conditionTrue = ilGenerator.DefineLabel();
            Label end = ilGenerator.DefineLabel();

            Type conditionType = Cond.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel); //genero el codigo de la condicion
            
            ilGenerator.Emit(OpCodes.Ldc_I4_0);
            ilGenerator.Emit(OpCodes.Bgt, conditionTrue); //voy para la etiqueta del true
            
            //es falsa la condicion
            Type elseType = Body_else.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel); //genero el codigo del cuerpo del else
            ilGenerator.Emit(OpCodes.Br, end); //voy para el final

            //la condicion fue true
            ilGenerator.MarkLabel(conditionTrue); //etiqueta del true
            Type thenType = Body.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel); //genero el codigo del cuerpo del then

            ilGenerator.MarkLabel(end); //etiqueta del fin
            return (elseType == typeof(object)) ? thenType : elseType; //como el else y el if devuelven lo mismo => devuelvo cualquiera de los dos
        }
    }
}
