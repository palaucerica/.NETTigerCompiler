using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class BreakNode : AtomicNode
    {        
        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            if (countOfClicles <= 0)
                errors.Add(new Error(line, column, "Solo se puede poner una sentencia break dentro de un ciclo"));
            return new ReturnBreak();
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldc_I4_1);
            ilGenerator.Emit(OpCodes.Stfld, IsBreakFields); //pongo el break en true
            ilGenerator.Emit(OpCodes.Br, endLabel); //salto pal final
            return null;
        }
    }
}
