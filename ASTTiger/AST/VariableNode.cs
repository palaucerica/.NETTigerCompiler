using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class VariableNode : ControlNode
    {
        public string Name { get; private set; }  
        public VariableNode(string name) 
        {
            Name = name;
        }
        public int NumLevelUp; //Cant de niveles a subir para buscar la declaracion de la variable
        public Var_Scope Variable { get; private set; }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            Variable = Utils.FindVar(scope_list, Name,ref NumLevelUp); //chequeo si la variable se encuentra declarada el scope           
            if (Variable == null)
            {
                //la variable id no esta en el scope
                errors.Add(new Error(line, column, "La variable '" + Name + "' no se encuentra definida en este ambito"));
                return null; //no se encontro en el scope
            }
            return Variable.Var_type;
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            GenCode(ilGenerator, level);

            ilGenerator.Emit(OpCodes.Ldfld, Variable.VarbBuilder); //busca la variable y deja su valor en el tope

            return Variable.Var_type.MyType(); //devuelvo el tipo de la variable
        }

        public void GenCode(ILGenerator ilGenerator, List<FieldBuilder> level)
        {
            int cant = 0;
            ilGenerator.Emit(OpCodes.Ldarg_0);

            while (NumLevelUp != cant)
            {
                ilGenerator.Emit(OpCodes.Ldfld, level[level.Count - 1 - cant]);
                cant++;
            }
        }
    }
}
