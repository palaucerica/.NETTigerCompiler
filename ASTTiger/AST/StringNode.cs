using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.IO;

namespace ASTTiger
{
    public class StringNode : AtomicNode
    {
        public string Value { get; private set; }

        public StringNode(string value)
        {
            Value = value.Substring(1, value.Length - 2); //para quitarme los primeros \
            Value = Value.Replace("\\n", "\n");
            Value = Value.Replace("\\t", "\t");
            Value = Value.Replace("\\\\", "\\");
            Value = Value.Replace("\\\"", "\"");
            //chequear si es un string de la forma \ddd
            string[] nums = Value.Split('\\');
            foreach (string t in nums)
            {
                string res;
                if (IsNumber(t, out res))
                    Value = Value.Replace("\\" + res, Convert.ToChar(int.Parse(res)).ToString());
            }

            int pos1 = 0;
            int pos2 = 0;
            while (pos1 != -1)
            {
                pos1 = Value.IndexOf('\\');
                if (pos1 != -1)
                {
                   pos2 = value.IndexOf('\\', pos1 + 2);
                   Value = Value.Remove(pos1, (pos2 - pos1)); 

                }
            }
            
        }

        private string DeleteSpaces(string code)
        {
            string result = "";
            if(code[0]=='\\')
            {
                result += "\\";
                foreach (var caracter in code)
                {
                    if (caracter == ' ')
                        result += ' ';
                    else
                    {
                        if (caracter == '\\')
                            return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Me chequea si una cadena empieza con 3 numeros y deja el numero en result
        /// </summary>
        /// <param name="code">String a chequear</param>
        /// <param name="result">Donde se deja el numero en caso de existir</param>
        /// <returns>Retorna true si la cadena 'code' empieza con 3 numeros y false en caso contrario</returns>
        private static bool IsNumber(string code, out string result)
        {
            result = "";
            if (code.Length >= 3)
            {
                try
                {
                    result += int.Parse(code[0].ToString());
                    result += int.Parse(code[1].ToString());
                    result += int.Parse(code[2].ToString());
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    //throw;
                }
            }
            return false;
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            return new ReturnString();
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields,
                                     List<FieldBuilder> level, Label endLabel)
        {
            ilGenerator.Emit(OpCodes.Ldstr, Value);
            //FileStream fs = new FileStream("prueba.txt",FileMode.Open,FileAccess.Write);
            //StreamWriter writer = new StreamWriter(fs);
            //writer.Write(Value);
            //writer.Close();
            //fs.Close();
            return typeof (string);
        }
    }
}
