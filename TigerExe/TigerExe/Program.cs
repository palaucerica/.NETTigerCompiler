using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASTTiger;
using System.IO;

namespace TigerExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" version 1.0 \n Copyright \n Alejandro Mustelier & Pedro A. Laucerica");
            LanguageNode root;
            if (args.Length > 0 && File.Exists(args[0] + ".tig"))
            {
                List<Error> errors = Compiler.Compile(args[0] + ".tig", Path.GetDirectoryName(args[0]), Path.GetFileName(args[0]), out root);
                foreach (var item in errors)
                {
                    Console.WriteLine("( {0}, {1} ): {2}", item.Line, item.PositionInLine, item.Message);
                }
            }
            else
                Console.WriteLine("File not found");
        }
    }
}
