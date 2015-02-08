using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace ASTTiger
{
    public class Utils
    {
        public static ModuleBuilder module;
        
        public static int autonumeric =0;
        public static int AutoNumeric
        {
            get { return autonumeric++; }
        }        

        /// <summary>
        /// Chequea si existe un tipo en un ambito determinado y devuelve su tipo de retorno
        /// </summary>
        /// <param name="scope_list">Lista de todos los ambitos</param>
        /// <param name="name">Nombre del tipo que se desea buscar</param>
        /// <returns>Devuelve el tipo de retorno si se encuentra y null en otro caso</returns>
        public static TypeReturn FindType(List<Scope> scope_list, string name)
        {
            for (int i = scope_list.Count() - 1; i >= 0; i--)
                if (scope_list[i].Types.ContainsKey(name)) return scope_list[i].Types[name];
            return null;
        }

        /// <summary>
        /// Chequea si el tipo es del sistema (int y string)
        /// </summary>
        /// <param name="name">Nombre del tipo</param>
        /// <returns>Retorna true si es 'int' o 'string' y false en otro caso</returns>
        public static bool IsSystemType(string name)
        {
            return name.ToLower().Equals("int") || name.ToLower().Equals("string");
        }

        /// <summary>
        /// Chequea si una funcion es de la libreria estandar
        /// </summary>
        /// <param name="first">Scope donde se encuentran todas las funciones de la libreria estandar</param>
        /// <param name="name">Nombre de la funcion</param>
        /// <returns>Retorna true si la funcion tiene el mismo nombre que alguna de la libreria estandar</returns>
        public static bool IsStandardFunction(Scope first, string name)
        {
            foreach (var item in first.Funcs) //recorro todas las funciones de la libreria estandar
            {
                if (item.Key.Equals(name.ToLower())) //pregunto si alguna tiene el mismo nombre 
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Chequea si una funcion se ha declarado en un ambito determinado y devuelve el tipo de retorno de la funcion (de encontrarse)
        /// </summary>
        /// <param name="scope_list">Lista de todos los ambitos de la funcion</param>
        /// <param name="name">Nombre de la funcion</param>
        /// <returns>Devuelve el tipo de retorno de la funcion dado su nombre o null si no se encuentra</returns>
        public static TypeReturn FindFunction(List<Scope> scope_list, string name, out Fun_Scope function,ref int up)
        {
            function = null;
            up = 0;
            for (int i = scope_list.Count() - 1; i >= 0; i--)//por cada scope
            {
                KeyValuePair<string, Fun_Scope> fun = scope_list[i].Funcs.FirstOrDefault(s => s.Key.Equals(name)); //busco si la funcion ya se declaro
                if (!fun.Equals(default(KeyValuePair<string, Fun_Scope>)))
                {
                    function = fun.Value;
                    return function.Retu;
                }
                up++;
            }           
            return null; //la funcion no esta definida en este scope
        }

        /// <summary>
        /// Chequea si una variable se ha declarado en un ambito determinado y devuelve el tipo de retorno de la variable (de encontrarse)
        /// </summary>
        /// <param name="scope_list">Lista de todos los ambitos</param>
        /// <param name="name">Nombre de la variable</param>
        /// <returns>Devuelve el tipo de retorno de la variable o null si no lo encuentra</returns>
        public static Var_Scope FindVar(List<Scope> scope_list, string name,ref int up)
        {
            up=0;
            for (int i = scope_list.Count() - 1; i >= 0; i--)//por cada scope
            {        
                KeyValuePair<string, Var_Scope> typeOfVar = scope_list[i].Vars.FirstOrDefault(s => s.Key.Equals(name)); //busco si la variable ya se declaro
                if (!typeOfVar.Equals(default(KeyValuePair<string, Var_Scope>)))
                    return typeOfVar.Value; //devuelvo el tipo de la variable
                up++;
            }           
            return null; //no se encontro el ambito
        }

        public static bool ExistsName(List<Scope> scope_list, string name)
        {
            for (int i = scope_list.Count() - 1; i >= 0; i--)
            {
                if (scope_list[i].Funcs.Any(s => s.Key.Equals(name))) return true;
                if (scope_list[i].Vars.Any(s => s.Key.Equals(name))) return true;
            }           
            return false;
        }

        //Ver si se le puede asignar valor a la variable
        public static bool NoAsignVar(List<Scope> scope_list, string name)
        {
            for (int i = scope_list.Count() - 1; i >= 0; i--)
            {
                KeyValuePair<string, Var_Scope> typeOfVar = scope_list[i].Vars.FirstOrDefault(s => s.Key.Equals(name)); //busco si la variable ya se declaro
                if (!typeOfVar.Equals(default(KeyValuePair<string, Var_Scope>)))
                    return typeOfVar.Value.NoAsign; //devuelvo el tipo de la variable
            }           
            return true; //no se encontro el ambito
        }
    }
}
