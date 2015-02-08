
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using ASTTiger;
using System.Diagnostics;
using System.IO;

namespace TestTiger2IL
{   
    
    /// <summary>
    ///This is a test class for CompilerTest and is intended
    ///to contain all CompilerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompilerTest
    {
        private TestContext testContextInstance;

        #region Semantics_Test_region

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Compile
        ///"no_errors"
        ///</summary>
        [TestMethod()]
        public void No_errors()
        {
            string inputProgram = "..\\..\\..\\tests\\success\\";
            string outputBinary = "..\\..\\..\\tests\\success\\";
            List<Tuple<string, string>> nameTest = new List<Tuple<string, string>>()
                                                {
                                                    new Tuple<string,string>("test1.tig","test1.exe"),
                                                    new Tuple<string,string>("test2.tig","test2.exe"),
                                                    new Tuple<string,string>("test3.tig","test3.exe"),
                                                    new Tuple<string,string>("test4.tig","test4.exe"),
                                                    new Tuple<string,string>("test5.tig","test5.exe"),
                                                    new Tuple<string,string>("test6.tig","test6.exe"),
                                                    new Tuple<string,string>("test7.tig","test7.exe"),
                                                    new Tuple<string,string>("test8.tig","test8.exe"),
                                                    new Tuple<string,string>("test12.tig","test12.exe"),
                                                    new Tuple<string,string>("test27.tig","test27.exe"),
                                                    new Tuple<string,string>("test30.tig","test30.exe"),
                                                    new Tuple<string,string>("test41.tig","test41.exe"),
                                                    new Tuple<string,string>("test42.tig","test42.exe"),
                                                    new Tuple<string,string>("test44.tig","test44.exe"),
                                                    new Tuple<string,string>("test46.tig","test46.exe"),
                                                    new Tuple<string,string>("merge.tig","merge.exe"),
                                                    new Tuple<string,string>("queens.tig","queens.exe"),
                                                    new Tuple<string,string>("array_string_nil.tig"," array_string_nil.exe"),
                                                    new Tuple<string,string>("array_init.tig"," array_init.exe"),
                                                    new Tuple<string,string>("access_complex.tig"," access_complex.exe"),
                                                    new Tuple<string,string>("call_function_nil.tig"," call_function_nil.exe"),
                                                    new Tuple<string,string>("array_of_nil.tig"," array_of_nil.exe"),
                                                    new Tuple<string,string>("record_fields_nil.tig"," record_fields_nil.exe"),
                                                    new Tuple<string,string>("3d_matrix.tig"," 3d_matrix.exe"),
                                                    new Tuple<string,string>("and_operator_shortcut.tig"," and_operator_shortcut.exe"),
                                                    new Tuple<string,string>("and_operator_simple.tig"," and_operator_simple.exe"),
                                                    new Tuple<string,string>("array_index_out_of_range_lower.tig"," array_index_out_of_range_lower.exe"),
                                                    new Tuple<string,string>("array_index_out_of_range_upper.tig"," array_index_out_of_range_upper.exe"),
                                                    new Tuple<string,string>("array_initialization.tig"," array_initialization.exe"),
                                                    new Tuple<string,string>("assigment.tig"," assigment.exe"),
                                                    new Tuple<string,string>("array_of_records.tig"," array_of_records.exe"),
                                                    new Tuple<string,string>("arrays_mara.tig"," arrays_mara.exe"),
                                                    new Tuple<string,string>("binary_search_tree.tig"," binary_search_tree.exe"),
                                                    new Tuple<string,string>("break_in_a_for.tig"," break_in_a_for.exe"),
                                                    new Tuple<string,string>("break_in_a_while.tig"," break_in_a_while.exe"),
                                                    new Tuple<string,string>("breaks.tig"," breaks.exe"),
                                                    new Tuple<string,string>("cicles.tig"," cicles.exe"),
                                                    new Tuple<string,string>("concat_string_in_array.tig"," concat_string_in_array.exe"),                                        
                                                    new Tuple<string,string>("divide_by_zero.tig"," divide_by_zero.exe"),
                                                    new Tuple<string,string>("divide_zero.tig"," divide_zero.exe"),
                                                    new Tuple<string,string>("empty_let.tig"," empty_let.exe"),
                                                    new Tuple<string,string>("equals_integer.tig"," equals_integer.exe"),
                                                    new Tuple<string,string>("equals_string.tig"," equals_string.exe"),                                                   
                                                    new Tuple<string,string>("estudiantes.tig"," estudiantes.exe"),
                                                    new Tuple<string,string>("fibonacci.tig"," fibonacci.exe"),
                                                    new Tuple<string,string>("for_and_array.tig"," for_and_array.exe"),
                                                    new Tuple<string,string>("for_with_break.tig"," for_with_break.exe"),
                                                    new Tuple<string,string>("getting_field_of_nil_record.tig"," getting_field_of_nil_record.exe"),
                                                    new Tuple<string,string>("greater_equals_than_integer.tig"," greater_equals_than_integer.exe"),
                                                    new Tuple<string,string>("greater_equals_than_string.tig"," greater_equals_than_string.exe"),
                                                    new Tuple<string,string>("greater_than_integer.tig"," greater_than_integer.exe"),
                                                    new Tuple<string,string>("greater_than_string.tig"," greater_than_string.exe"),
                                                    new Tuple<string,string>("hanoi_towers.tig"," hanoi_towers.exe"),
                                                    new Tuple<string,string>("hello_world.tig"," hello_world.exe"),
                                                    new Tuple<string,string>("integer_literal.tig"," integer_literal.exe"),
                                                    new Tuple<string,string>("killer.tig"," killer.exe"),
                                                    new Tuple<string,string>("less_equals_than_integer.tig"," less_equals_than_integer.exe"),
                                                    new Tuple<string,string>("less_equals_than_string.tig"," less_equals_than_string.exe"),
                                                    new Tuple<string,string>("less_than_integer.tig"," less_than_integer.exe"),
                                                    new Tuple<string,string>("less_than_string.tig"," less_than_string.exe"),
                                                    new Tuple<string,string>("linked_list.tig"," linked_list.exe"),
                                                    new Tuple<string,string>("localf.tig"," localf.exe"),
                                                    new Tuple<string,string>("matrix.tig"," matrix.exe"),
                                                    new Tuple<string,string>("matrix_of_minus_ones.tig"," matrix_of_minus_ones.exe"),
                                                    new Tuple<string,string>("killer.tig"," killer.exe"),
                                                    new Tuple<string,string>("mergesort.tig"," mergesort.exe"),
                                                    new Tuple<string,string>("modify_function_parameters.tig"," modify_function_parameters.exe"),
                                                    new Tuple<string,string>("mult_array_size.tig"," mult_array_size.exe"),
                                                    new Tuple<string,string>("multiple_lines_string_literal.tig"," multiple_lines_string_literal.exe"),
                                                    new Tuple<string,string>("nil_literal.tig"," nil_literal.exe"),
                                                    new Tuple<string,string>("not_equals_integer.tig"," not_equals_integer.exe"),
                                                    new Tuple<string,string>("not_equals_string.tig"," not_equals_string.exe"),
                                                    new Tuple<string,string>("one_houndred.tig"," one_houndred.exe"),
                                                    new Tuple<string,string>("or_operator_shortcut.tig"," or_operator_shortcut.exe"),
                                                    new Tuple<string,string>("or_operator_simple.tig"," or_operator_simple.exe"),
                                                    new Tuple<string,string>("ping_pong.tig"," ping_pong.exe"),
                                                    new Tuple<string,string>("read_matrix.tig"," read_matrix.exe"),
                                                    new Tuple<string,string>("recursive_function_with_scope.tig"," recursive_function_with_scope.exe"),
                                                    new Tuple<string,string>("simple_array.tig"," simple_array.exe"),
                                                    new Tuple<string,string>("simple_assigment.tig"," simple_assigment.exe"),
                                                    new Tuple<string,string>("simple_comments.tig"," simple_comments.exe"),
                                                    new Tuple<string,string>("simple_divide.tig"," simple_divide.exe"),
                                                    new Tuple<string,string>("simple_expression_sequence.tig"," simple_expression_sequence.exe"),
                                                    new Tuple<string,string>("simple_for.tig"," simple_for.exe"),
                                                    new Tuple<string,string>("simple_if_then.tig","simple_if_then.exe"),
                                                    new Tuple<string,string>("simple_if_then_else_else_non_valued.tig","simple_if_then_else_else_non_valued.exe"),
                                                    new Tuple<string,string>("simple_if_then_else_else_valued.tig","simple_if_then_else_else_valued.exe"),
                                                    new Tuple<string,string>("simple_if_then_else_then_non_valued.tig"," simple_if_then_else_then_non_valued.exe"),
                                                    new Tuple<string,string>("simple_if_then_else_then_valued.tig","simple_if_then_else_then_valued.exe"),
                                                    new Tuple<string,string>("simple_let.tig","simple_let.exe"),
                                                    new Tuple<string,string>("simple_minus.tig","simple_minus.exe"),
                                                    new Tuple<string,string>("simple_plus.tig","simple_plus.exe"),
                                                    new Tuple<string,string>("simple_record.tig","simple_record.exe"),
                                                    new Tuple<string,string>("simple_times.tig","simple_times.exe"),
                                                    new Tuple<string,string>("simple_unary_minus.tig","simple_unary_minus.exe"),
                                                    new Tuple<string,string>("simple_while.tig","simple_while.exe"),
                                                    new Tuple<string,string>("stdlib_chr.tig","stdlib_chr.exe"),
                                                    new Tuple<string,string>("stdlib_concat.tig","stdlib_concat.exe"),
                                                    new Tuple<string,string>("stdlib_exit.tig","stdlib_exit.exe"),
                                                    new Tuple<string,string>("stdlib_getchar.tig","stdlib_getchar.exe"),
                                                    new Tuple<string,string>("stdlib_concat.tig","stdlib_concat.exe"),
                                                    new Tuple<string,string>("stdlib_not.tig","stdlib_not.exe"),
                                                    new Tuple<string,string>("stdlib_ord.tig","stdlib_ord.exe"),
                                                    new Tuple<string,string>("stdlib_size.tig","stdlib_size.exe"),
                                                    new Tuple<string,string>("stdlib_substring.tig","stdlib_substring.exe"),
                                                    new Tuple<string,string>("string_literal.tig","string_literal.exe"),
                                                    new Tuple<string,string>("testing_scopes.tig","testing_scopes.exe"),
                                                    new Tuple<string,string>("treelist.tig","treelist.exe"),
                                                    new Tuple<string,string>("valid_nested_comments.tig","valid_nested_comments.exe")
                                                };
            LanguageNode l;
            foreach (var test in nameTest)
            {
                Compiler.Compile(inputProgram + test.Item1, null, outputBinary + test.Item2, out l);
                Assert.AreEqual(Compiler.Errors.Count, 0, "El test " + test.Item1 + " no debe dar error");
                if (Compiler.Errors.Count > 0)
                {
                    Assert.Fail("Los errores que dio fueron: ", Compiler.Errors.ToArray());
                }
            }
        }

        /// <summary>
        ///A test for Compile
        ///"test9"
        ///</summary>
        [TestMethod()]
        public void test_test9()
        {
            string testName = "test9";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"Los tipos retornados por las expresiones del then y del else tienen que ser iguales")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test Failed ", testName);


        }

        /// <summary>
        ///A test for Compile
        ///"test10"
        ///</summary>
        [TestMethod()]
        public void test_test10()
        {
            string testName = "test10";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"La expresion del body del while no debe retornar ningun valor")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test11"
        ///</summary>
        [TestMethod()]
        public void test_test11()
        {
            string testName = "test11";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"La expresion del To debe retornar un entero"),
                                        new Error(0,0,"No se le puede asignar ningún valor a la variable 'i'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test13"
        ///</summary>
        [TestMethod()]
        public void test_test13()
        {
            string testName = "test13";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"Ambas expresiones deben ser de tipo 'int' o de tipo 'string'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test14"
        ///</summary>
        [TestMethod()]
        public void test_test14()
        {
            string testName = "test14";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo 'rectype' con una del tipo 'arrtype'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test15"
        ///</summary>
        [TestMethod()]
        public void test_test15()
        {
            string testName = "test15";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"La expresion del cuerpo del if no puede devolver ningun valor")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test16"
        ///</summary>
        [TestMethod()]
        public void test_test16()
        {
            string testName = "test16";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test17"
        ///</summary>
        [TestMethod()]
        public void test_test17()
        {
            string testName = "test17";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"No existe el tipo con el nombre 'treelist'"),
                                        new Error(0,0,"No existe el tipo con el nombre 'tree'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test18"
        ///</summary>
        [TestMethod()]
        public void test_test18()
        {
            string testName = "test18";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"La funcion 'do_nothing2' no esta declarada en este ambito")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test19"
        ///</summary>
        [TestMethod()]
        public void test_test19()
        {
            string testName = "test19";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test21"
        ///</summary>
        [TestMethod()]
        public void test_test21()
        {
            string testName = "test21";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"La expresión derecha de la operación binaria debe ser entera"),
                                        new Error(0,0,"El procedimiento 'nfactor' no debe retornar valor")
                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test22"
        ///</summary>
        [TestMethod()]
        public void test_test22()
        {
            string testName = "test22";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"El record no tiene ningun campo llamado nam"),
                                        new Error(0,0,"No se le puede asignar un 'string' a un 'rectype'")                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test23"
        ///</summary>
        [TestMethod()]
        public void test_test23()
        {
            string testName = "test23";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"No se le puede asignar un 'int' a un 'string'"), 
                                        new Error(0,0,"No se le puede asignar un 'string' a un 'int'")                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test24"
        ///</summary>
        [TestMethod()]
        public void test_test24()
        {
            string testName = "test24";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"El tipo que se desea indexar no es un array"),                                                                             
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test25"
        ///</summary>
        [TestMethod()]
        public void test_test25()
        {
            string testName = "test25";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"El tipo no es un record"),                                                                             
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test26"
        ///</summary>
        [TestMethod()]
        public void test_test26()
        {
            string testName = "test26";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"La expresión derecha de la operación binaria debe ser entera"),                                                                             
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test28"
        ///</summary>
        [TestMethod()]
        public void test_test28()
        {
            string testName = "test28";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"No se le puede asignar un 'rectype2' a un 'rectype1'"),
                                         new Error(0,0,"La variable 'rec1' no se encuentra definida en este ambito")                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test29"
        ///</summary>
        [TestMethod()]
        public void test_test29()
        {
            string testName = "test29";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"No se le puede asignar un 'arrtype2' a un 'arrtype1'"),
                                         new Error(0,0,"La variable 'arr1' no se encuentra definida en este ambito")                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test31"
        ///</summary>
        [TestMethod()]
        public void test_test31()
        {
            string testName = "test31";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"No se le puede asignar un 'string' a un 'int'"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito")                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test32"
        ///</summary>
        [TestMethod()]
        public void test_test32()
        {
            string testName = "test32";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"Los elementos del array son de tipo 'int' y no de tipo 'string'"),
                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test33"
        ///</summary>
        [TestMethod()]
        public void test_test33()
        {
            string testName = "test33";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"mismatched input '}' expecting ID",true),
                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test34"
        ///</summary>
        [TestMethod()]
        public void test_test34()
        {
            string testName = "test34";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"El parametro 'a' no es de tipo 'int'"),
                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test35"
        ///</summary>
        [TestMethod()]
        public void test_test35()
        {
            string testName = "test35";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"El parametro 'a' no es de tipo 'int'"),
                                        new Error(0,0,"La funcion 'g' no tiene 1 parametros")
                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test36"
        ///</summary>
        [TestMethod()]
        public void test_test36()
        {
            string testName = "test36";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                       
                                        new Error(0,0,"La funcion 'g' no tiene 3 parametros")
                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test38"
        ///</summary>
        [TestMethod()]
        public void test_test37()
        {
            string testName = "test37";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                       
                                        new Error(0,0,"El nombre de la variable 'a' ya esta en uso")
                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test38"
        ///</summary>
        [TestMethod()]
        public void test_test38()
        {
            string testName = "test38";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Existe un tipo con el nombre 'a'")                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test39"
        ///</summary>
        [TestMethod()]
        public void test_test39()
        {
            string testName = "test39";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El nombre de la función 'g' ya esta en uso")                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test40"
        ///</summary>
        [TestMethod()]
        public void test_test40()
        {
            string testName = "test40";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El procedimiento 'g' no debe retornar valor")                                                     
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test43"
        ///</summary>
        [TestMethod()]
        public void test_test43()
        {
            string testName = "test43";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"No se puede inferir el tipo"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito"),
                                         new Error(0,0,"La expresión izquierda de la operación binaria debe ser entera")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test45"
        ///</summary>
        [TestMethod()]
        public void test_test45()
        {
            string testName = "test45";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"No se puede inferir el tipo"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test47"
        ///</summary>
        [TestMethod()]
        public void test_test47()
        {
            string testName = "test47";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Existe un tipo con el nombre 'a'")
                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"test48"
        ///</summary>
        [TestMethod()]
        public void test_test48()
        {
            string testName = "test48";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El nombre de la función 'g' ya esta en uso")                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"create_type_string"
        ///</summary>
        [TestMethod()]
        public void test_create_type_string()
        {
            string testName = "create_type_string";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"No se puede crear un tipo con el nombre de 'int' o de 'string'"),
                                        new Error(0,0,"No se le puede asignar un 'int' a un 'string'")                                      
                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);


        }

        /// <summary>
        ///A test for Compile
        ///"create_function_print"
        ///</summary>
        [TestMethod()]
        public void test_create_function_print()
        {
            string testName = "create_function_print";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Hay una funcion en la libreria estandar con el nombre 'print'")                                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"type_nameSame"
        ///</summary>
        [TestMethod()]
        public void test_type_nameSame()
        {
            string testName = "type_nameSame";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Existe un tipo con el nombre 'MyType'")                                      
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"break"
        ///</summary>
        [TestMethod()]
        public void test_break()
        {
            string testName = "break";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La parte derecha de la asignacion debe devolver algun valor"), 
                                        new Error(0,0,"No se le puede asignar un 'No valor' a un 'int'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"break2"
        ///</summary>
        [TestMethod()]
        public void test_break2()
        {
            string testName = "break2";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La parte derecha de la asignacion debe devolver algun valor"), 
                                        new Error(0,0,"No se le puede asignar un 'No valor' a un 'int'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"break3"
        ///</summary>
        [TestMethod()]
        public void test_break3()
        {
            string testName = "break3";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La parte derecha de la asignacion debe devolver algun valor"), 
                                        new Error(0,0,"No se le puede asignar un 'No valor' a un 'int'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"and_operator_invalid_type_operands"
        ///</summary>
        [TestMethod()]
        public void test_and_operator_invalid_type_operands()
        {
            string testName = "and_operator_invalid_type_operands";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La expresión derecha de la operación lógica debe ser entera"), 
                                        new Error(0,0,"La expresión izquierda de la operación lógica debe ser entera"),
                                        new Error(0,0,"La expresión izquierda de la operación lógica debe ser entera"),
                                        new Error(0,0,"La expresión derecha de la operación lógica debe ser entera")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"and_operator_non_valued_operands"
        ///</summary>
        [TestMethod()]
        public void test_and_operator_non_valued_operands()
        {
            string testName = "and_operator_non_valued_operands";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La expresión derecha de la operación lógica debe ser entera"), 
                                        new Error(0,0,"La expresión izquierda de la operación lógica debe ser entera"),
                                        new Error(0,0,"La expresión izquierda de la operación lógica debe ser entera"),
                                        new Error(0,0,"La expresión derecha de la operación lógica debe ser entera")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"and_operator_returns_value"
        ///</summary>
        [TestMethod()]
        public void test_and_operator_returns_value()
        {
            string testName = "and_operator_returns_value";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La expresion del body del while no debe retornar ningun valor")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"break_in_a_function"
        ///</summary>
        [TestMethod()]
        public void test_break_in_a_function()
        {
            string testName = "break_in_a_function";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Solo se puede poner una sentencia break dentro de un ciclo"),
                                         new Error(0,0,"No coincide el tipo de retorno con el que debería retornar"),
                                         new Error(0,0,"Solo se puede poner una sentencia break dentro de un ciclo"),
                                         new Error(0,0,"No coincide el tipo de retorno con el que debería retornar")                                          
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"break_out_of_for"
        ///</summary>
        [TestMethod()]
        public void test_break_out_of_for()
        {
            string testName = "break_out_of_for";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Solo se puede poner una sentencia break dentro de un ciclo"),                                         
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"break_out_of_while"
        ///</summary>
        [TestMethod()]
        public void test_break_out_of_while()
        {
            string testName = "break_out_of_while";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Solo se puede poner una sentencia break dentro de un ciclo"),                                         
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"differents_types_array_assign"
        ///</summary>
        [TestMethod()]
        public void test_differents_types_array_assign()
        {
            string testName = "differents_types_array_assign";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"No se le puede asignar un 'arrayinteger' a un 'arrayint'"),                                         
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"divide_between_non_valued_right"
        ///</summary>
        [TestMethod()]
        public void test_divide_between_non_valued_right()
        {
            string testName = "divide_between_non_valued_right";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La expresión derecha de la operación binaria debe ser entera"),                                         
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"expression_sequence_returns_last_value"
        ///</summary>
        [TestMethod()]
        public void test_expression_sequence_returns_last_value()
        {
            string testName = "expression_sequence_returns_last_value";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La condicion del if debe retornar un entero"),
                                        new Error(0,0,"Los tipos retornados por las expresiones del then y del else tienen que ser iguales")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"if_then_else_without_return_value"
        ///</summary>
        [TestMethod()]
        public void test_if_then_else_without_return_value()
        {
            string testName = "if_then_else_without_return_value";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La condicion del while debe retornar un entero")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        /// <summary>
        ///A test for Compile
        ///"if_then_without_valued_condition"
        ///</summary>
        [TestMethod()]
        public void test_if_then_without_valued_condition()
        {
            string testName = "if_then_without_valued_condition";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Solo se puede poner una sentencia break dentro de un ciclo"),
                                        new Error(0,0,"La condicion del if debe retornar un entero"),
                                        new Error(0,0,"Solo se puede poner una sentencia break dentro de un ciclo")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"incompatible_types_jagged_array"
        ///</summary>
        [TestMethod()]
        public void test_incompatible_types_jagged_array()
        {
            string testName = "incompatible_types_jagged_array";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"No se le puede asignar un 'string' a un 'int'")                                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"inferred_variable_incompatibles_type"
        ///</summary>
        [TestMethod()]
        public void test_inferred_variable_incompatibles_type()
        {
            string testName = "inferred_variable_incompatibles_type";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo 'int' con una del tipo 'string'"),
                                        new Error(0,0,"No se le puede asignar un 'string' a un 'int'"),
                                        new Error(0,0,"No se le puede asignar un 'int' a un 'string'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"invalid_mutually_recursive_function_depth_3"
        ///</summary>
        [TestMethod()]
        public void test_invalid_mutually_recursive_function_depth_3()
        {
            string testName = "invalid_mutually_recursive_function_depth_3";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El tipo del parámetro 'b' de la función no existe"),                                       
                                        new Error(0,0,"La funcion 'h' no esta declarada en este ambito"),
                                        new Error(0,0,"La funcion 'f' no esta declarada en este ambito")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"invalid_mutually_recursive_function_depth_4"
        ///</summary>
        [TestMethod()]
        public void test_invalid_mutually_recursive_function_depth_4()
        {
            string testName = "invalid_mutually_recursive_function_depth_4";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El tipo del parámetro 'b' de la función no existe"),                                        
                                        new Error(0,0,"La funcion 'h' no esta declarada en este ambito"),
                                        new Error(0,0,"La funcion 'i' no esta declarada en este ambito"),                                        
                                        new Error(0,0,"La funcion 'f' no esta declarada en este ambito")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"invalid_mutually_recursive_record"
        ///</summary>
        [TestMethod()]
        public void test_invalid_mutually_recursive_record()
        {
           /* string testName = "invalid_mutually_recursive_record";
             string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
             string outputBinary = "..\\..\\..\\tests\\";

             LanguageNode l;
             Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
             List<Error> expected = new List<Error>()
                                     {                                       
                                        
                                     };
             Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
             for (int i = 0; i < expected.Count; i++)
                 Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);*/

        }

        // <summary>
        ///A test for Compile
        ///"invalid_mutually_recursive_record_depth_3"
        ///</summary>
        [TestMethod()]
        public void test_invalid_mutually_recursive_record_depth_3()
        {
            string testName = "invalid_mutually_recursive_record_depth_3";
             string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
             string outputBinary = "..\\..\\..\\tests\\";

             LanguageNode l;
             Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
             List<Error> expected = new List<Error>()
                                     {
                                         new Error(0,0,"No existe el tipo con el nombre 'C'")                                       
                                     };
             Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
             for (int i = 0; i < expected.Count; i++)
                 Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"invalid_mutually_recursive_record_depth_4"
        ///</summary>
        [TestMethod()]
        public void test_invalid_mutually_recursive_record_depth_4()
        {
            string testName = "invalid_mutually_recursive_record_depth_4";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                     {  
                                        new Error(0,0,"No existe el tipo con el nombre 'C'"),
                                        new Error(0,0,"No existe el tipo con el nombre 'H'"),
                                        new Error(0,0,"No se pudo resolver el alias 'C'")                                   
                                     };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"multiple_alias_errors"
        ///</summary>
        [TestMethod()]
        public void test_multiple_alias_errors()
        {
            string testName = "multiple_alias_errors";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"mutually_recursive_alias"
        ///</summary>
        [TestMethod()]
        public void test_mutually_recursive_alias()
        {
            string testName = "mutually_recursive_alias";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"procedure_same_parameters_name"
        ///</summary>
        [TestMethod()]
        public void test_procedure_same_parameters_name()
        {
            string testName = "procedure_same_parameters_name";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Existe más de un parámetro con el nombre 'a'"),
                                        new Error(0,0,"Existe más de un parámetro con el nombre 'b'"),
                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"record_access_incompatibles_types"
        ///</summary>
        [TestMethod()]
        public void test_record_access_incompatibles_types()
        {
            string testName = "record_access_incompatibles_types";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"No se le puede asignar un 'human' a un 'int'"),
                                        new Error(0,0,"Las expresiones comparadas no son del mismo tipo,no se puede comparar una expresion del Tipo 'human' con una del tipo 'int'")                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"record_literal_invalid_types"
        ///</summary>
        [TestMethod()]
        public void test_record_literal_invalid_types()
        {
            string testName = "record_literal_invalid_types";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Solo se puede asignar nil a un tipo record, array o string"),
                                        new Error(0,0,"El record 'human'. El tipo del campo 'siblin' es 'human' y no 'int'"),
                                        
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"record_literal_less_params"
        ///</summary>
        [TestMethod()]
        public void test_record_literal_less_params()
        {
            string testName = "record_literal_less_params";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El record 'human' no tiene 1 campos")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"record_literal_more_params"
        ///</summary>
        [TestMethod()]
        public void test_record_literal_more_params()
        {
            string testName = "record_literal_more_params";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El record 'human' no tiene 2 campos")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"recursive_array"
        ///</summary>
        [TestMethod()]
        public void test_recursive_array()
        {
            string testName = "recursive_array";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El array 'a' es recursivo , es mutuamente recursivo o su tipo es invalido")                                      
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"recursive_array_alias"
        ///</summary>
        [TestMethod()]
        public void test_recursive_array_alias()
        {
            string testName = "recursive_array_alias";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"El array 'c' es recursivo , es mutuamente recursivo o su tipo es invalido")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"undefined_type_for_alias"
        ///</summary>
        [TestMethod()]
        public void test_undefined_type_for_alias()
        {
            string testName = "undefined_type_for_alias";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array"),
                                        new Error(0,0,"Error en el alias el tipo no pasa a traves de ningún record o array")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"undefined_type_for_array_declaration"
        ///</summary>
        [TestMethod()]
        public void test_undefined_type_for_array_declaration()
        {
            string testName = "undefined_type_for_array_declaration";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El array 'arrayint' es recursivo , es mutuamente recursivo o su tipo es invalido")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"record_fields_nil_error"
        ///</summary>
        [TestMethod()]
        public void record_fields_nil_error()
        {
            string testName = "record_fields_nil_error";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"Solo se puede asignar nil a un tipo record, array o string"),
                                        new Error(0,0,"La variable 'est' no se encuentra definida en este ambito"),
                                        new Error(0,0,"No se le puede asignar ningún valor a la variable 'est'")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"call_function_nil_error"
        ///</summary>
        [TestMethod()]
        public void record_call_function_nil_error()
        {
            string testName = "call_function_nil_error";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"No se le puede asignar un 'nil' a un 'int'"),                                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);

        }

        // <summary>
        ///A test for Compile
        ///"array_of_int_error"
        ///</summary>
        [TestMethod()]
        public void record_array_of_int_error()
        {
            string testName = "array_of_int_error";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"El array no permite 'nil' porque los valores del array son 'int'"),
                                        new Error(0,0,"La variable 'b' no se encuentra definida en este ambito"),
                                        new Error(0,0,"No se le puede asignar ningún valor a la variable 'b'")                                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);
        }

        // <summary>
        ///A test for Compile
        ///"default_value_array_variable"
        ///</summary>
        [TestMethod()]
        public void default_value_array_variable()
        {
            string testName = "default_value_array_variable";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La funcion 'f' no esta declarada en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito"),
                                        new Error(0,0,"El tipo que se desea indexar no es un array")
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);
        }

        // <summary>
        ///A test for Compile
        ///"default_value_int_variable"
        ///</summary>
        [TestMethod()]
        public void default_value_int_variable()
        {
            string testName = "default_value_int_variable";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La funcion 'f' no esta declarada en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito")                                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);
        }

        // <summary>
        ///A test for Compile
        ///"default_value_record_variable"
        ///</summary>
        [TestMethod()]
        public void default_value_record_variable()
        {
            string testName = "default_value_record_variable";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La funcion 'f' no esta declarada en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito")                                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);
        }

        // <summary>
        ///A test for Compile
        ///"default_value_string_variable"
        ///</summary>
        [TestMethod()]
        public void default_value_string_variable()
        {
            string testName = "default_value_string_variable";
            string inputProgram = "..\\..\\..\\tests\\" + testName + ".tig";
            string outputBinary = "..\\..\\..\\tests\\";

            LanguageNode l;
            Compiler.Compile(inputProgram, outputBinary, outputBinary + testName + ".exe", out l);
            List<Error> expected = new List<Error>()
                                    {                                       
                                        new Error(0,0,"La funcion 'f' no esta declarada en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito"),
                                        new Error(0,0,"La variable 'a' no se encuentra definida en este ambito")                                       
                                    };
            Assert.AreEqual(expected.Count, Compiler.Errors.Count, "El test " + testName + "la cantidad de errores fueron distintos");
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], Compiler.Errors[i], "{0} Test fallido ", testName);
        }        

        #endregion        


        #region GenerateCode_Test_Region
      

        public void TestSuccess(string testName)
        {
            List<Error> expected = new List<Error>();
            LanguageNode ctree;
            List<Error> actual = Compiler.Compile("..\\..\\..\\tests\\success\\" + testName + ".tig", "..\\..\\..\\tests\\success\\outputs\\", testName, out ctree);

            Assert.AreEqual<int>(expected.Count, actual.Count, "{0} Failed to Compile ", testName);
            var myOutput = GetText("..\\..\\..\\tests\\success\\outputs\\" + testName + ".exe");
            StreamReader SR = new StreamReader("..\\..\\..\\tests\\success\\" + testName + ".out");
            string output = SR.ReadToEnd();
            SR.Close();

            if (!(new FileInfo("..\\..\\..\\tests\\success\\" + testName + ".out").Exists) ||
                            (new FileInfo("..\\..\\..\\tests\\success\\" + testName + ".err").Exists) ||
                            (new FileInfo("..\\..\\..\\tests\\success\\" + testName + ".in").Exists))
            {
                Assert.Inconclusive(testName + " No pudo comprobarse la prueba.");
            }
            else
                Assert.AreEqual<string>(output, myOutput, "{0} Test Failed ", testName);
        }
        
       /// <summary>
       ///A test for Compile
       ///"3d_matrix"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_3d_matrix()
       {
           string testName = "3d_matrix";
           TestSuccess(testName);
       }
       /// <summary>
       ///A test for Compile
       ///"and_operator_shortcut"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_and_operator_shortcut()
       {
           string testName = "and_operator_shortcut";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"and_operator_simple"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_and_operator_simple()
       {
           string testName = "and_operator_simple";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_queens"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_queens()
       {
           string testName = "appel_queens";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test1"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test1()
       {
           string testName = "appel_test1";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test12"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test12()
       {
           string testName = "appel_test12";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test2"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test2()
       {
           string testName = "appel_test2";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test27"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test27()
       {
           string testName = "appel_test27";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test3"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test3()
       {
           string testName = "appel_test3";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test30"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test30()
       {
           string testName = "appel_test30";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test4"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test4()
       {
           string testName = "appel_test4";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test41"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test41()
       {
           string testName = "appel_test41";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test42"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test42()
       {
           string testName = "appel_test42";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test44"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test44()
       {
           string testName = "appel_test44";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test46"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test46()
       {
           string testName = "appel_test46";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test5"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test5()
       {
           string testName = "appel_test5";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"appel_test8"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_appel_test8()
       {
           string testName = "appel_test8";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"arrays_mara"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_arrays_mara()
       {
           string testName = "arrays_mara";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"array_initialization"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_array_initialization()
       {
           string testName = "array_initialization";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"array_of_records"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_array_of_records()
       {
           string testName = "array_of_records";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"assigment"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_assigment()
       {
           string testName = "assigment";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"binary_search_tree"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_binary_search_tree()
       {
           string testName = "binary_search_tree";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"breaks"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_breaks()
       {
           string testName = "breaks";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"break_in_a_for"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_break_in_a_for()
       {
           string testName = "break_in_a_for";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"break_in_a_while"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_break_in_a_while()
       {
           string testName = "break_in_a_while";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"cicles"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_cicles()
       {
           string testName = "cicles";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"concat_string_in_array"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_concat_string_in_array()
       {
           string testName = "concat_string_in_array";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"empty_let"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_empty_let()
       {
           string testName = "empty_let";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"equals_integer"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_equals_integer()
       {
           string testName = "equals_integer";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"equals_string"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_equals_string()
       {
           string testName = "equals_string";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"estudiantes"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_estudiantes()
       {
           string testName = "estudiantes";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"fibonacci"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_fibonacci()
       {
           string testName = "fibonacci";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"for_and_array"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_for_and_array()
       {
           string testName = "for_and_array";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"for_with_break"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_for_with_break()
       {
           string testName = "for_with_break";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"greater_equals_than_integer"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_greater_equals_than_integer()
       {
           string testName = "greater_equals_than_integer";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"greater_equals_than_string"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_greater_equals_than_string()
       {
           string testName = "greater_equals_than_string";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"greater_than_integer"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_greater_than_integer()
       {
           string testName = "greater_than_integer";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"greater_than_string"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_greater_than_string()
       {
           string testName = "greater_than_string";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"hanoi_towers"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_hanoi_towers()
       {
           string testName = "hanoi_towers";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"hello_world"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_hello_world()
       {
           string testName = "hello_world";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"integer_literal"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_integer_literal()
       {
           string testName = "integer_literal";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"killer"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_killer()
       {
           string testName = "killer";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"less_equals_than_integer"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_less_equals_than_integer()
       {
           string testName = "less_equals_than_integer";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"less_equals_than_string"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_less_equals_than_string()
       {
           string testName = "less_equals_than_string";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"less_than_integer"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_less_than_integer()
       {
           string testName = "less_than_integer";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"less_than_string"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_less_than_string()
       {
           string testName = "less_than_string";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"localf"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_localf()
       {
           string testName = "localf";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"matrix"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_matrix()
       {
           string testName = "matrix";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"matrix_of_minus_ones"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_matrix_of_minus_ones()
       {
           string testName = "matrix_of_minus_ones";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"mergesort"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_mergesort()
       {
           string testName = "mergesort";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"modify_function_parameters"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_modify_function_parameters()
       {
           string testName = "modify_function_parameters";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"multiple_lines_string_literal"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_multiple_lines_string_literal()
       {
           string testName = "multiple_lines_string_literal";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"mult_array_size"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_mult_array_size()
       {
           string testName = "mult_array_size";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"nil_literal"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_nil_literal()
       {
           string testName = "nil_literal";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"not_equals_integer"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_not_equals_integer()
       {
           string testName = "not_equals_integer";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"not_equals_string"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_not_equals_string()
       {
           string testName = "not_equals_string";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"one_houndred"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_one_houndred()
       {
           string testName = "one_houndred";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"or_operator_shortcut"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_or_operator_shortcut()
       {
           string testName = "or_operator_shortcut";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"or_operator_simple"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_or_operator_simple()
       {
           string testName = "or_operator_simple";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"ping_pong"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_ping_pong()
       {
           string testName = "ping_pong";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"recursive_function_with_scope"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_recursive_function_with_scope()
       {
           string testName = "recursive_function_with_scope";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_array"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_array()
       {
           string testName = "simple_array";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_assigment"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_assigment()
       {
           string testName = "simple_assigment";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_comments"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_comments()
       {
           string testName = "simple_comments";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_divide"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_divide()
       {
           string testName = "simple_divide";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_expression_sequence"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_expression_sequence()
       {
           string testName = "simple_expression_sequence";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_for"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_for()
       {
           string testName = "simple_for";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_if_then"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_if_then()
       {
           string testName = "simple_if_then";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_if_then_else_else_non_valued"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_if_then_else_else_non_valued()
       {
           string testName = "simple_if_then_else_else_non_valued";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_if_then_else_else_valued"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_if_then_else_else_valued()
       {
           string testName = "simple_if_then_else_else_valued";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_if_then_else_then_non_valued"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_if_then_else_then_non_valued()
       {
           string testName = "simple_if_then_else_then_non_valued";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_if_then_else_then_valued"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_if_then_else_then_valued()
       {
           string testName = "simple_if_then_else_then_valued";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_let"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_let()
       {
           string testName = "simple_let";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_minus"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_minus()
       {
           string testName = "simple_minus";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_plus"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_plus()
       {
           string testName = "simple_plus";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_record"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_record()
       {
           string testName = "simple_record";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_times"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_times()
       {
           string testName = "simple_times";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_unary_minus"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_unary_minus()
       {
           string testName = "simple_unary_minus";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"simple_while"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_simple_while()
       {
           string testName = "simple_while";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"stdlib_chr"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_stdlib_chr()
       {
           string testName = "stdlib_chr";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"stdlib_concat"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_stdlib_concat()
       {
           string testName = "stdlib_concat";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"stdlib_exit"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_stdlib_exit()
       {
           string testName = "stdlib_exit";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"stdlib_not"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_stdlib_not()
       {
           string testName = "stdlib_not";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"stdlib_ord"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_stdlib_ord()
       {
           string testName = "stdlib_ord";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"stdlib_size"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_stdlib_size()
       {
           string testName = "stdlib_size";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"stdlib_substring"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_stdlib_substring()
       {
           string testName = "stdlib_substring";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"string_literal"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_string_literal()
       {
           string testName = "string_literal";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"testing_scopes"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_testing_scopes()
       {
           string testName = "testing_scopes";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"treelist"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_treelist()
       {
           string testName = "treelist";
           TestSuccess(testName);
       }

       /// <summary>
       ///A test for Compile
       ///"valid_nested_comments"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_valid_nested_comments()
       {
           string testName = "valid_nested_comments";
           TestSuccess(testName);
       }
    
        /// <summary>
       ///A test for Compile
       ///"access_complex"
       ///</summary>
       [TestMethod()]
       public void CompileTest_Success_access_complex()
       {
           string testName = "access_complex";
           TestSuccess(testName);
       }

      

       private string GetText(string filename)
       {
           Process p = new Process();
           p.StartInfo.FileName = filename;
           p.StartInfo.RedirectStandardOutput = true;
           p.StartInfo.UseShellExecute = false;
           p.Start();
           string actualOutput = p.StandardOutput.ReadToEnd();
           p.WaitForExit();
           p.Close();
           return actualOutput;
       }
        #endregion
    }
}
