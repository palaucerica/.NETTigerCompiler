# .NETTigerCompiler
Compiler for the programming language Tiger developed in .NET. 

The Compiler has 3 phases:

1- Sintactic Analysis.
2- Semantics Analysis.
3- Code Generation.

The first phase was implemented using the tool ANTLR. This tool generate a Lexer and a Parser using a grammar described.
The second and third phases was implemented in C#. In the 3rd phase the Compiler generates IL code

Description of the contents of the folders:

-ASTTiger: Contains all the logic of the compiler.

-TestTiger2IL: Contains Unit tests to prove the correctness of the compiler.

-TigerExe: Executable that allows you use the compiler. 

-tests: Files with extensions ".tig" that can be used for testing the compiler. Some tests have errors, the ones that 
doesn't have errors are located in the folder ../tests/success/

To run the compiler:

-Open the command prompt change the current working directory to the path ../NETTigerCompiler/TigerExe/TigerExe/bin/Debug/
 and run the "TigerExe.exe" with the full path of the file with extension ".tig" you want to compile.
-If the file has syntax or semantic errors the compiler displays them, otherwise, the compiler generates a file .exe.

