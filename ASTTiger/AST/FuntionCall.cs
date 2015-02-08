using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class FuntionCall : ControlNode
    {
        public List<LanguageNode> Param { get; private set; }
        public string Name { get; private set; }
        public FuntionCall(List<LanguageNode> param, string name) 
        {
            Param = param;
            Name = name;
        }
        int NumLevelUp;
        Fun_Scope fun;

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            TypeReturn typeOfFun = Utils.FindFunction(scope_list, Name, out fun,ref NumLevelUp); //chequear que la funcion este definida en el scope
            if (typeOfFun == null)
            {
                errors.Add(new Error(line, column, "La funcion '" + Name + "' no esta declarada en este ambito"));
                return null; //no se encontro la funcion en el scope
            }

            //para no irme de rango en el for y no tener que estar preguntando cual es menor o mayor
            int min = Math.Min(Param.Count, fun.Param.Count); //me quedo con el minimo de la cantidad de parametros entre la functioncall y la declarada

            //voy comparando los parametros y viendo que devuelvan lo mismo
            for (int i = 0; i < min; i++)
            {
                TypeReturn type = Param[i].CheckSemantics(scope_list, errors); //le hago el chequeo semantico a cada parametro (tienen que devolver algun valor)
                if (type == null) continue;

                if (type is ReturnNil)
                {
                    if (fun.Param[i].Item2 is ReturnInt)
                        errors.Add(new Error(line, column, "No se le puede asignar un '" + type + "' a un '" + fun.Param[i].Item2 + "'")); //añado el error
                }
                else if (!type.ToString().Equals(fun.Param[i].Item2.ToString())) //pregunto si el parametro i-esimo de la functioncall es del mismo tipo que del declarado
                    errors.Add(new Error(line, column, "El parametro '" + fun.Param[i].Item1 + "' no es de tipo '" + fun.Param[i].Item2+"'"));

                if (type is ReturnNotValue) //pregunto si el i-esimo parametro devuelve algun valor (tienen que hacerlo)
                    errors.Add(new Error(line, column, "La expresion del parametro " + i + "-esimo no devuelve valor"));
            }

            if (fun.Param.Count != Param.Count) //para saber si tienen la misma cantidad de parametros la funcioncall que la declarada
                errors.Add(new Error(line, column, "La funcion '" + Name + "' no tiene " + Param.Count + " parametros"));

            return typeOfFun; //es null si la funcion no se encontro en el Scope
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            if (fun.IsSystem)
            {
                //llamo al metodo
                MethodBuilder mb = StandarLibrary.SelectFunction(Name);

                foreach (var par in Param)
                    //Genero codigo de cada parámetro y se mete en la pila
                    par.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel);

                // Llamar al método que representa el cuerpo de la función
                ilGenerator.Emit(OpCodes.Call,mb);
            }
            else
            {
                int cant = 0;
                ilGenerator.Emit(OpCodes.Ldarg_0);

                while (NumLevelUp != cant)
                {
                    ilGenerator.Emit(OpCodes.Ldfld, level[level.Count - 1 - cant]);
                    cant++;
                }

                foreach (var par in Param)
                    //Genero codigo de cada parámetro y se mete en la pila
                    par.GenCode(ilGenerator, parent, IsBreakFields, level, endLabel);

                // Crear una instancia del tipo que representa la función
                ilGenerator.Emit(OpCodes.Newobj, fun.constr);

                // Llamar al método que representa el cuerpo de la función
                ilGenerator.Emit(OpCodes.Callvirt, fun.meth);
            }
            return fun.Retu.MyType();
        }
    }
}
