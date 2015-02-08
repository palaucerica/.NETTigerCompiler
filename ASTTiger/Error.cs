using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTTiger
{
    public class Error
    {
        public int Line { get; private set; }
        public int PositionInLine { get; private set; }
        public string Message { get; private set; }      

        public Error(int line,int column,string message) 
        {
            Line = line;
            PositionInLine = column;
            Message ="Error semántico: "+ message;
            
        }

        public Error(int line, int column, string message,bool syn)
        {
            Line = line;
            PositionInLine = column;
            Message = (syn) ? "Error sintáctico: " + message : "Error semántico: " + message;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Error)) return false;
            return Message == ((Error)obj).Message;
        }
    }
}
