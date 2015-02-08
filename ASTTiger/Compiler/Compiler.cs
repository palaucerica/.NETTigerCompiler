using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using System.Reflection.Emit;
using System.Reflection;

namespace ASTTiger
{
    public class Compiler
    {
        private static ANTLRFileStream stream;
        private static TigerPM_ASTLexer lexer;
        private static CommonTokenStream tokens;
        private static TigerPM_ASTParser parser;
        public static List<Error> Errors = new List<Error>();

        /// <summary>
        /// Compila un string que constituye un programa escrito en tiger. 
        /// </summary>
        /// <param name="programPath">Ruta al fichero de entrada</param>
        /// <param name="outputFolder">Fichero de salida</param>
        /// <returns>Lista de errores que tiene el programa</returns>
        public static List<Error> Compile(string programPath, string outputFolder, string outputFilename,
                                          out LanguageNode root)
        {
            root = null;

            stream = new ANTLRFileStream(programPath);
            lexer = new TigerPM_ASTLexer(stream);
            Errors.Clear();
            tokens = new CommonTokenStream(lexer);
            parser = new TigerPM_ASTParser(tokens);
            Utils.autonumeric = 0;
            InstructionNode.countOfClicles = 0;
           
            var result = parser.prog();

            if (Errors.Count == 0)
            {
                root = result;

                if (Errors.Count == 0)
                {
//No hubo errores sintacticos

                    //Crear el Scope
                    Scope scope = new Scope();
                    scope.Types.Add("int", new ReturnInt());
                    scope.Types.Add("string", new ReturnString());
                    scope.Funcs.Add("print",
                                    new Fun_Scope("print",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("s", new ReturnString())},
                                                  new ReturnNotValue(), true));
                    scope.Funcs.Add("printi",
                                    new Fun_Scope("printi",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("i", new ReturnInt())},
                                                  new ReturnNotValue(), true));
                    scope.Funcs.Add("flush",
                                    new Fun_Scope("flush", new List<Tuple<string, TypeReturn>>(), new ReturnNotValue(),
                                                  true));
                    scope.Funcs.Add("getchar",
                                    new Fun_Scope("getchar", new List<Tuple<string, TypeReturn>>(), new ReturnString(),
                                                  true));
                    scope.Funcs.Add("ord",
                                    new Fun_Scope("ord",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("s", new ReturnString())},
                                                  new ReturnInt(), true));
                    scope.Funcs.Add("chr",
                                    new Fun_Scope("chr",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("i", new ReturnInt())},
                                                  new ReturnString(), true));
                    scope.Funcs.Add("size",
                                    new Fun_Scope("size",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("s", new ReturnString())},
                                                  new ReturnInt(), true));
                    scope.Funcs.Add("substring",
                                    new Fun_Scope("substring",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {
                                                          new Tuple<string, TypeReturn>("s", new ReturnString()),
                                                          new Tuple<string, TypeReturn>("f", new ReturnInt()),
                                                          new Tuple<string, TypeReturn>("n", new ReturnInt())
                                                      },
                                                  new ReturnString(), true));
                    scope.Funcs.Add("concat",
                                    new Fun_Scope("concat",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {
                                                          new Tuple<string, TypeReturn>("s1", new ReturnString()),
                                                          new Tuple<string, TypeReturn>("s2", new ReturnString())
                                                      },
                                                  new ReturnString(), true));
                    scope.Funcs.Add("not",
                                    new Fun_Scope("not",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("i", new ReturnInt())},
                                                  new ReturnInt(), true));
                    scope.Funcs.Add("exit",
                                    new Fun_Scope("exit",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("i", new ReturnInt())},
                                                  new ReturnNotValue(), true));
                    scope.Funcs.Add("printline",
                                    new Fun_Scope("printline",
                                                  new List<Tuple<string, TypeReturn>>()
                                                      {new Tuple<string, TypeReturn>("s", new ReturnString())},
                                                  new ReturnNotValue(), true));
                    scope.Funcs.Add("getline",
                                    new Fun_Scope("getline", new List<Tuple<string, TypeReturn>>(), new ReturnString(),
                                                  true));
                    List<Scope> s = new List<Scope>();
                    s.Add(scope);

                    root.CheckSemantics(s, Errors);

                    if (Errors.Count == 0 && outputFolder != null)
                    {
                        GenCode(root, outputFolder, outputFilename);
                    }
                } //No hubo errores sintacticos
            }
            return Errors;

        }

        /// <summary>
        /// Ejecuta un programa.
        /// </summary>
        /// <param name="inputPath">Fichero a ejecutar</param>
        public static void Run(string inputPath)
        {

        }

        /// <summary>
        /// Genera el codigo de un programa semanticamente correcto. Este metodo es solo de uso interno
        /// </summary>
        /// <param name="root"></param>
        /// <param name="folder"></param>
        /// <param name="filename"></param>
        private static void GenCode(LanguageNode root, string folder, string filename)
        {
            AssemblyName name = new AssemblyName("TigerPM");

            #region INICIALIZACION

            // Creando el ensamblado.              
            AssemblyBuilder assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(name,
                                                                                     AssemblyBuilderAccess.RunAndSave,
                                                                                     folder);

            // Creando el módulo.
            Utils.module = assembly.DefineDynamicModule(filename + ".exe");

            // Creando la clase Program.
            TypeBuilder program = Utils.module.DefineType("Program", TypeAttributes.Public | TypeAttributes.Class);

            ConstructorBuilder programCrt = program.DefineConstructor(MethodAttributes.Public,
                                                                      CallingConventions.Standard, new Type[0]);
            FieldBuilder field = program.DefineField("Break", typeof (bool), FieldAttributes.Public);
            ILGenerator ilG = programCrt.GetILGenerator();
            ilG.Emit(OpCodes.Ldarg_0); //meto el this
            ilG.Emit(OpCodes.Ldc_I4_0); //meto un cero en la pila
            ilG.Emit(OpCodes.Stfld, field);
            ilG.Emit(OpCodes.Ret);

            // Creando el método Run.
            MethodBuilder run = program.DefineMethod("Run", MethodAttributes.Public, CallingConventions.Standard,
                                                     typeof (void), new Type[0]);
            ILGenerator runIL = run.GetILGenerator();

            #region CODIGO DEL PROGRAMA

            StandarLibrary.stanLib = null;
            StandarLibrary.meths = new Dictionary<string, MethodBuilder>();

            Type t = root.GenCode(runIL, program, field, new List<FieldBuilder>(), default(Label));
            if (t != null && t != typeof (void))
                runIL.Emit(OpCodes.Call, typeof (Console).GetMethod("Write", new Type[] {t}));
                    //para ver lo que devuelve

            if (StandarLibrary.stanLib != null) StandarLibrary.stanLib.CreateType();

            #endregion

            runIL.Emit(OpCodes.Ret);

            // Creando el método Main.
            MethodBuilder main = program.DefineMethod("Main", MethodAttributes.Public | MethodAttributes.Static,
                                                      CallingConventions.Standard, typeof (void), new Type[0]);
            main.InitLocals = true;

            // Haciendo el método Main el punto de entrada
            // de la aplicación.
            assembly.SetEntryPoint(main, PEFileKinds.ConsoleApplication);

            main.InitLocals = true;

            ILGenerator mainGen = main.GetILGenerator();

            mainGen.Emit(OpCodes.Newobj, programCrt);
            mainGen.Emit(OpCodes.Callvirt, run);

            #endregion


            #region FINALIZACION

            // Hacer que el método Main retorne.
            mainGen.Emit(OpCodes.Ret);

            // Crear la clase Program.
            program.CreateType();
            // Guardar el ensamblado.
            assembly.Save(Utils.module.ToString());

            #endregion
        }
    }
}
