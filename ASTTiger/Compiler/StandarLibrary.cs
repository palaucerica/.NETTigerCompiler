using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.IO;

namespace ASTTiger
{
    public class StandarLibrary
    {
        public static TypeBuilder stanLib;
        public static Dictionary<string, MethodBuilder> meths;

        public static MethodBuilder SelectFunction(string name) 
        {
            switch (name)
            {
                case "print": return print(Utils.module);

                case "printi": return printi(Utils.module);

                case "printline": return printline(Utils.module);

                case "getline": return getline(Utils.module);

                case "size": return size(Utils.module);

                case "substring": return substring(Utils.module);

                case "concat": return concat(Utils.module);

                case "not": return not(Utils.module);

                case "chr": return chr(Utils.module);

                case "ord": return ord(Utils.module);

                case "exit": return exit(Utils.module);

                case "flush": return flush(Utils.module);

                case "getchar": return getchar(Utils.module);
            }
            return null;
        }





        private static MethodBuilder getchar(ModuleBuilder mb)
        {           

            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("getchar"))
                return meths["getchar"];

            //creo el método
            meths["getchar"] = stanLib.DefineMethod("getchar", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(string), new Type[0] { });

            ILGenerator ig = meths["getchar"].GetILGenerator();

            ig.Emit(OpCodes.Call, typeof(Console).GetProperty("In").GetGetMethod());
            ig.Emit(OpCodes.Callvirt, typeof(TextReader).GetMethod("Read", new Type[0]));

            // Convertir a Char
            ig.Emit(OpCodes.Call, typeof(Convert).GetMethod("ToChar", new Type[] { typeof(int) }));
            // Convertir a String
            ig.Emit(OpCodes.Call, typeof(Convert).GetMethod("ToString", new Type[] { typeof(char) }));           

            ig.Emit(OpCodes.Ret);
            return meths["getchar"];
        }

        private static MethodBuilder flush(ModuleBuilder mb)
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("flush"))
                return meths["flush"];

            //creo el método
            meths["flush"] = stanLib.DefineMethod("flush", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(void), new Type[0] { });

            ILGenerator ig = meths["flush"].GetILGenerator();
            ig.Emit(OpCodes.Call, typeof(Console).GetProperty("Out").GetGetMethod());
            ig.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod("Flush"));

            ig.Emit(OpCodes.Ret);
            return meths["flush"];
        }

        public static MethodBuilder print(ModuleBuilder mb)
        {
            if(stanLib==null)            
                //creo la instancia de la clase.
                stanLib=mb.DefineType("StandarLibrary",TypeAttributes.Public | TypeAttributes.Class );
            
            if (meths.ContainsKey("print"))            
                return meths["print"];            

            //creo el método
            meths["print"] = stanLib.DefineMethod("print", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(void), new Type[] { typeof(string)});

            ILGenerator ig= meths["print"].GetILGenerator();
            ig.Emit(OpCodes.Call, typeof(Console).GetProperty("Out").GetGetMethod());
            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod("Write", new Type[] { typeof(string) }));

            ig.Emit(OpCodes.Ret);
            return meths["print"];
        }

        public static MethodBuilder printi(ModuleBuilder mb)
        {
            if (stanLib == null)            
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);
            
            if (meths.ContainsKey("printi"))            
                return meths["printi"];            

            //creo el método
            meths["printi"] = stanLib.DefineMethod("printi", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(void), new Type[] { typeof(int) });

            ILGenerator ig = meths["printi"].GetILGenerator();
            ig.Emit(OpCodes.Call, typeof(Console).GetProperty("Out").GetGetMethod());
            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod("Write", new Type[] { typeof(int) }));

            ig.Emit(OpCodes.Ret);
            return meths["printi"];
        }

        public static MethodBuilder printline(ModuleBuilder mb)
        {
            if (stanLib == null)            
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);
            
            if (meths.ContainsKey("printline"))            
                return meths["printline"];            

            //creo el método
            meths["printline"] = stanLib.DefineMethod("printline", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(void), new Type[] { typeof(string) });

            ILGenerator ig = meths["printline"].GetILGenerator();
            ig.Emit(OpCodes.Call, typeof(Console).GetProperty("Out").GetGetMethod());
            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod("WriteLine", new Type[] { typeof(string) }));
            
            ig.Emit(OpCodes.Ret);
            return meths["printline"];
        }

        public static MethodBuilder getline(ModuleBuilder mb)
        {
            if (stanLib == null)            
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);
            
            if (meths.ContainsKey("getline"))            
                return meths["getline"];            

            //creo el método
            meths["getline"] = stanLib.DefineMethod("getline", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(string), new Type[0]);

            ILGenerator ig = meths["getline"].GetILGenerator();
            ig.Emit(OpCodes.Call, typeof(Console).GetProperty("In").GetGetMethod());
            ig.Emit(OpCodes.Callvirt, typeof(TextReader).GetMethod("ReadLine", new Type[0]));

            ig.Emit(OpCodes.Ret);
            return meths["getline"];
        }

        public static MethodBuilder size(ModuleBuilder mb) 
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("size"))
                return meths["size"];

            //creo el método
            meths["size"] = stanLib.DefineMethod("size", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(int), new Type[]{typeof(string)});

            ILGenerator ig = meths["size"].GetILGenerator();
            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Callvirt, typeof(string).GetProperty("Length").GetGetMethod());
            
            ig.Emit(OpCodes.Ret);
            return meths["size"];
        }

        public static MethodBuilder substring(ModuleBuilder mb)
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("substring"))
                return meths["substring"];

            //creo el método
            meths["substring"] = stanLib.DefineMethod("substring", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(string), new Type[] { typeof(string), typeof(int), typeof(int) });

            ILGenerator ig = meths["substring"].GetILGenerator();            
            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Ldarg_1);
            ig.Emit(OpCodes.Ldarg_2);           
            ig.Emit(OpCodes.Callvirt, typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) }));

            ig.Emit(OpCodes.Ret);
            return meths["substring"];
        }

        public static MethodBuilder concat(ModuleBuilder mb)
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("concat"))
                return meths["concat"];

            //creo el método
            meths["concat"] = stanLib.DefineMethod("concat", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(string), new Type[] { typeof(string), typeof(string) });

            ILGenerator ig = meths["concat"].GetILGenerator();
            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Ldarg_1);
            ig.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));

            ig.Emit(OpCodes.Ret);
            return meths["concat"];
        }

        public static MethodBuilder not(ModuleBuilder mb)
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("not"))
                return meths["not"];

            //creo el método
            meths["not"] = stanLib.DefineMethod("not", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(int), new Type[] { typeof(int) });

            ILGenerator ig = meths["not"].GetILGenerator();

            Label verd = ig.DefineLabel();
            Label fin = ig.DefineLabel();

            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Ldc_I4_0);

            ig.Emit(OpCodes.Beq, verd);

            ig.Emit(OpCodes.Ldc_I4_0);
            ig.Emit(OpCodes.Br, fin);

            ig.MarkLabel(verd);
            ig.Emit(OpCodes.Ldc_I4_1);

            ig.MarkLabel(fin);

            ig.Emit(OpCodes.Ret);
            return meths["not"];
        }

        public static MethodBuilder chr(ModuleBuilder mb)
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("chr"))
                return meths["chr"];

            //creo el método
            meths["chr"] = stanLib.DefineMethod("chr", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(string), new Type[] { typeof(int) });

            ILGenerator ig = meths["chr"].GetILGenerator();
            Label error = ig.DefineLabel();
            Label fin = ig.DefineLabel();

            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Ldc_I4, 255);
            ig.Emit(OpCodes.Bgt, error);

            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Ldc_I4_0);
            ig.Emit(OpCodes.Blt, error);

            ig.Emit(OpCodes.Ldarg_0);
            // Convertir a Char
            ig.Emit(OpCodes.Call, typeof(Convert).GetMethod("ToChar", new Type[] { typeof(int) }));
            // Convertir a String
            ig.Emit(OpCodes.Call, typeof(Convert).GetMethod("ToString", new Type[] { typeof(char) }));
            ig.Emit(OpCodes.Br, fin);

            ig.MarkLabel(error);

            ig.Emit(OpCodes.Ldstr, "");
            ig.Emit(OpCodes.Ldc_I4_1);
            ig.Emit(OpCodes.Call, typeof(Environment).GetMethod("Exit", new Type[] { typeof(int) }));

            ig.MarkLabel(fin);          

            ig.Emit(OpCodes.Ret);
            return meths["chr"];
        }

        public static MethodBuilder ord(ModuleBuilder mb)
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("ord"))
                return meths["ord"];

            //creo el método
            meths["ord"] = stanLib.DefineMethod("ord", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(int), new Type[] { typeof(string) });

            ILGenerator ig = meths["ord"].GetILGenerator();

            Label vacia = ig.DefineLabel();
            Label fin = ig.DefineLabel();

            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Callvirt, typeof(string).GetProperty("Length").GetGetMethod());
            ig.Emit(OpCodes.Ldc_I4_0);
            ig.Emit(OpCodes.Beq, vacia);

            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Ldc_I4_0);
            ig.Emit(OpCodes.Callvirt, typeof(string).GetMethod("get_Chars", new Type[] { typeof(int) }));
            // Convertir a Int32
            ig.Emit(OpCodes.Call, typeof(Convert).GetMethod("ToInt32", new Type[] { typeof(char) }));

            ig.Emit(OpCodes.Br, fin);

            ig.MarkLabel(vacia);

            ig.Emit(OpCodes.Ldc_I4,-1);

            ig.MarkLabel(fin);


            ig.Emit(OpCodes.Ret);
            return meths["ord"];
        }

        public static MethodBuilder exit(ModuleBuilder mb)
        {
            if (stanLib == null)
                //creo la instancia de la clase.
                stanLib = mb.DefineType("StandarLibrary", TypeAttributes.Public | TypeAttributes.Class);

            if (meths.ContainsKey("exit"))
                return meths["exit"];

            //creo el método
            meths["exit"] = stanLib.DefineMethod("exit", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, typeof(void), new Type[] { typeof(int) });

            ILGenerator ig = meths["exit"].GetILGenerator();
            ig.Emit(OpCodes.Ldarg_0);
            ig.Emit(OpCodes.Call, typeof(Environment).GetMethod("Exit", new Type[] { typeof(int) }));

            ig.Emit(OpCodes.Ret);
            return meths["exit"];
        }
    }
}
