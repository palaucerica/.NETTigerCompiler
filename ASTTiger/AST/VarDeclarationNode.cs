using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace ASTTiger
{
    public class VarDeclarationNode : DeclarationNode
    {
        public string Name { get; private set; }
        public LanguageNode Asig { get; private set; }
        public string VarType { get; private set; }      
        Var_Scope v;
        public TypeReturn TipoVariable { get; set; }


        public VarDeclarationNode(string name, LanguageNode asig)
        {
            Name = name;
            Asig = asig;
        }

        public VarDeclarationNode(string name, string var_type, LanguageNode asig)
        {
            Name = name;
            Asig = asig;
            VarType = var_type;
        }

        void FindTipoVariable(List<Scope> scope_list, string s)
        {
            TipoVariable = Utils.FindType(scope_list, s);
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            int cant = errors.Count;//me da la cant de errores que hay hasta el momento

            TypeReturn typeOfAsign = Asig.CheckSemantics(scope_list, errors);
            TypeReturn typeVar;

            if (typeOfAsign == null) //cuando no existe la asignación            
                return new ReturnNotValue();

            if (VarType == null) //no tiene tipo la variable
            {
                if ((typeOfAsign is ReturnNil) || (typeOfAsign is ReturnNotValue)) //si es nil o no retorna valor no se puede inferir el tipo
                {
                    errors.Add(new Error(line, column, "No se puede inferir el tipo"));
                    return new ReturnNotValue();
                }
                //Var_type = typeOfAsign.ToString(); //se infiere el tipo
                typeVar = typeOfAsign;
            }

            //tiene tipo la variable (VarType!=null)
            else
            {
                typeVar = Utils.FindType(scope_list, VarType); //busco el tipo de la variable
                if (typeVar == null)
                {
                    errors.Add(new Error(line, column, "El tipo de la variable '" + Name + "' no existe"));
                        //añado el error
                    return null;
                }
                // el tipo de la variable existe
                if (typeOfAsign is ReturnNil) //pregunto si la asignacion es nil y el Lvalue permite nil
                {
                    if (typeVar is ReturnInt)
                        errors.Add(new Error(line, column,
                                             "No se le puede asignar un '" + typeOfAsign.ToString() + "' a un '" +
                                             typeVar + "'")); //añado el error
                }
                else if (!typeVar.Equals(typeOfAsign))
                    errors.Add(new Error(line, column,
                                         "No se le puede asignar un '" + typeOfAsign.ToString() + "' a un '" +
                                         typeVar + "'")); //añado el error
            }

            if (scope_list[scope_list.Count - 1].Vars.ContainsKey(Name) || scope_list[scope_list.Count - 1].Funcs.ContainsKey(Name)) //ver si hay una funcion o una variable con ese nombre
                errors.Add(new Error(line, column, "El nombre de la variable '" + Name + "' ya esta en uso")); //añado el error

            if (cant == errors.Count) //si no hubo errores 
            {
                v = new Var_Scope(Name, typeVar);
                scope_list[scope_list.Count - 1].Vars.Add(Name, v); //añado la variable al scope           
            }
            return new ReturnNotValue();
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            FieldBuilder field = parent.DefineField(Name,v.Var_type.MyType(), FieldAttributes.Public);
            ilGenerator.Emit(OpCodes.Ldarg_0); //meto el this
            Asig.GenCode(ilGenerator, parent,IsBreakFields,level, endLabel); //meto el valor a asignar en la pila
            ilGenerator.Emit(OpCodes.Stfld, field); //asigna el valor del argumento al campo field
            v.VarbBuilder = field; //guardo el FieldBuilder de la variable para usarlo en el GenCode de VariableNode

            return null;
        }
    }
}
