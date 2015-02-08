using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class ReturnArray : TypeReturn
    {
        public string Array_name { get; private set; } //contiene el nombre del array, es para las comparaciones
        //public int Count_elements { get; private set; } //contiene la cantidad de elementos del array
        public TypeReturn Type_Of_Elements { get;  set; } //contiene el tipo de retorno de los elementos del array

        public ReturnArray(string array_name, TypeReturn type_of_elements)
        {
            this.Array_name = array_name;
            this.Type_Of_Elements = type_of_elements;
        }
       

        public override bool Equals(object obj)
        {
            ReturnArray r = obj as ReturnArray;
            if (r == null || r.Array_name != Array_name) return false;
            return true;
        }

        public override string ToString()
        {
            return Array_name;
        }

        public override Type MyType()
        {
            return Array.CreateInstance(Type_Of_Elements.MyType(), 0).GetType();
        }
    }
}
