using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
	public class AsignNode : ControlNode
	{
		public LanguageNode LValue { get; private set; }
		public LanguageNode Asign { get; private set; }
		public AsignNode(LanguageNode lvalue, LanguageNode asign) 
		{
			LValue = lvalue;
			Asign = asign;
		}

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn typeOfAsign = Asign.CheckSemantics(scope_list, errors); //hago el chequeo semantico de la asignacion
               
            if (typeOfAsign is ReturnNotValue) //verifico que devuelva algun valor
                errors.Add(new Error(line, column, "La parte derecha de la asignacion debe devolver algun valor"));

            TypeReturn typeOfLvalue = LValue.CheckSemantics(scope_list, errors); //hago el chequeo semantico del Lvalue
            if (LValue is VariableNode && Utils.NoAsignVar(scope_list, ((VariableNode) LValue).Name))
                errors.Add(new Error(line, column,
                                     "No se le puede asignar ningún valor a la variable '" +
                                     ((VariableNode) LValue).Name + "'"));

            if (typeOfAsign is ReturnNil) //pregunto si la parte derecha es nil
            {
                if (typeOfLvalue is ReturnInt) //un entero no permite nil (todos los demas tipos si)
                    errors.Add(new Error(line, column,
                                         "No se le puede asignar un '" + typeOfAsign + "' a un '" + typeOfLvalue + "'"));
            }
            else if (typeOfLvalue != null && typeOfAsign != null &&  //pregunto si no hubo problema con el chequeo de las variables
                     !typeOfLvalue.ToString().Equals(typeOfAsign.ToString())) //chequeo que los tipos sean iguales
                errors.Add(new Error(line, column,
                                     "No se le puede asignar un '" + typeOfAsign + "' a un '" + typeOfLvalue + "'"));

            return new ReturnNotValue(); //la asignacion no devuelve valor
        }

	    public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
		{
			if (LValue is VariableNode)
			{
				(LValue as VariableNode).GenCode(ilGenerator, level); //puede ser un access node (deja en el tope la referencia al objeto)
				//LocalBuilder local = ilGenerator.DeclareLocal(LvalueType);
				//ilGenerator.Emit(OpCodes.Stloc, local);
				Asign.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel); //deja en el tope el valor

				ilGenerator.Emit(OpCodes.Stfld, (LValue as VariableNode).Variable.VarbBuilder);
			}
			else
			{
				//es un accesNode
                FieldBuilder last = null;
                Type type = null;
                bool isRecord = (LValue as AccessNode).GenCode(ilGenerator, parent, IsBreakFields, level, endLabel, ref last, ref type); //genero el codigo del access node (deja en el tope un valor)
                if (isRecord)
                {
                    //ilGenerator.Emit(OpCodes.Ldloc)
                    //ilGenerator.Emit(OpCodes.Ldfld, last);
                    //fue un acceso a record lo ultimo que se hizo => en el tope queda la referencia
                    Asign.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel); //genero el codigo de la asignacion
                    //necesito el fieldBuilder del campo del record que se quedo en el tope
                    ilGenerator.Emit(OpCodes.Stfld, last);
                }
                else
                {
                    //es un array
                    Asign.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel); //genero el codigo de la asignacion
                    ilGenerator.Emit(OpCodes.Stelem, type);
                }
			}
			
			return null; //la asignacion no devuelve valor
		}
	}
}
