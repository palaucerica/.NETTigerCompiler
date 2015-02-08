using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class IfThenNode : ControlNode
    {
        public LanguageNode Cond { get; private set; }
        public LanguageNode Body { get; private set; }
        
        public IfThenNode(LanguageNode cond, LanguageNode body) 
        {
            Cond = cond;
            Body = body;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            CheckCondition(scope_list, errors); //chequeo que la expresion de la condicion devuelva un entero
            
            TypeReturn typeOfBody = Body.CheckSemantics(scope_list, errors);
            if (!(typeOfBody is ReturnNotValue)) //La expresion del body no puede retornar ningun valor
                errors.Add(new Error(line, column, "La expresion del cuerpo del if no puede devolver ningun valor"));
            
            if (typeOfBody is ReturnBreak) //pregunto si el body del if es un break para saberlo por si estoy dentro de un exp-sec 
                return new ReturnBreak();

            return new ReturnNotValue(); //si no retorno ningun valor
        }

        /// <summary>
        /// Chequea que la expresion de la condicion devuelva un entero
        /// </summary>
        /// <param name="scope_list">Lista de scope de la expresion de la condicion</param>
        /// <param name="errors">Lista de errores</param>
        protected void CheckCondition(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn typeOfCond = Cond.CheckSemantics(scope_list, errors);
            if (!(typeOfCond is ReturnInt))  //La expresion de la condicional del if tiene que devolver un entero
                errors.Add(new Error(line, column, "La condicion del if debe retornar un entero"));
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            Label conditionFalse = ilGenerator.DefineLabel();
            Type condit = Cond.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel); //en el tope queda el valor de la condicion
            ilGenerator.Emit(OpCodes.Ldc_I4_0); //meto el 0 en el tope de la pila
            
            ilGenerator.Emit(OpCodes.Ble, conditionFalse); //si cond <=0 es false

            //si se cumple la condicion
            Type bodyType = Body.GenCode(ilGenerator,parent,IsBreakFields,level, endLabel); //genero el condigo del body del if

            ilGenerator.MarkLabel(conditionFalse);

            return null;
        }
    }
}
