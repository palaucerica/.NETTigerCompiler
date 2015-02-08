// $ANTLR 3.2 Sep 23, 2009 12:02:23 C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g 2012-05-10 13:11:15


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public class TigerPM_ASTLexer : Lexer {
    public const int Pto = 26;
    public const int End = 22;
    public const int COMMENTLINE = 46;
    public const int LETTER = 48;
    public const int ESC = 53;
    public const int MenorIgual = 34;
    public const int Comilla = 43;
    public const int Asign = 18;
    public const int While = 12;
    public const int ID = 50;
    public const int SPACE = 52;
    public const int EOF = -1;
    public const int CARACT = 51;
    public const int Nil = 44;
    public const int LLlave = 6;
    public const int Let = 20;
    public const int COMMENTS = 45;
    public const int To = 17;
    public const int LCorch = 4;
    public const int Do = 15;
    public const int DIGIT = 49;
    public const int Distin = 31;
    public const int Or = 37;
    public const int FUNCION = 42;
    public const int If = 9;
    public const int And = 36;
    public const int Div = 30;
    public const int RParen = 14;
    public const int In = 21;
    public const int PtoComa = 25;
    public const int DOSPTOS = 40;
    public const int Suma = 27;
    public const int LParen = 13;
    public const int Then = 10;
    public const int Mayor = 33;
    public const int RLlave = 7;
    public const int INT = 55;
    public const int Equal = 23;
    public const int For = 16;
    public const int Menor = 32;
    public const int Menos = 28;
    public const int Mult = 29;
    public const int WS = 47;
    public const int Break = 19;
    public const int ArrayOf = 39;
    public const int Coma = 24;
    public const int RCorch = 5;
    public const int Else = 11;
    public const int Of = 8;
    public const int Var = 41;
    public const int MayorIgual = 35;
    public const int TypeToken = 38;
    public const int STRING = 54;

    // delegates
    // delegators

    public TigerPM_ASTLexer() 
    {
		InitializeCyclicDFAs();
    }
    public TigerPM_ASTLexer(ICharStream input)
		: this(input, null) {
    }
    public TigerPM_ASTLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g";} 
    }

    // $ANTLR start "LCorch"
    public void mLCorch() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LCorch;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:7:8: ( '[' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:7:10: '['
            {
            	Match('['); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LCorch"

    // $ANTLR start "RCorch"
    public void mRCorch() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RCorch;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:8:8: ( ']' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:8:10: ']'
            {
            	Match(']'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RCorch"

    // $ANTLR start "LLlave"
    public void mLLlave() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LLlave;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:9:8: ( '{' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:9:10: '{'
            {
            	Match('{'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LLlave"

    // $ANTLR start "RLlave"
    public void mRLlave() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RLlave;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:10:8: ( '}' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:10:10: '}'
            {
            	Match('}'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RLlave"

    // $ANTLR start "Of"
    public void mOf() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Of;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:11:4: ( 'of' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:11:6: 'of'
            {
            	Match("of"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Of"

    // $ANTLR start "If"
    public void mIf() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = If;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:12:4: ( 'if' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:12:6: 'if'
            {
            	Match("if"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "If"

    // $ANTLR start "Then"
    public void mThen() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Then;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:13:6: ( 'then' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:13:8: 'then'
            {
            	Match("then"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Then"

    // $ANTLR start "Else"
    public void mElse() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Else;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:14:6: ( 'else' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:14:8: 'else'
            {
            	Match("else"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Else"

    // $ANTLR start "While"
    public void mWhile() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = While;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:15:7: ( 'while' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:15:9: 'while'
            {
            	Match("while"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "While"

    // $ANTLR start "LParen"
    public void mLParen() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LParen;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:16:8: ( '(' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:16:10: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LParen"

    // $ANTLR start "RParen"
    public void mRParen() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RParen;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:17:8: ( ')' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:17:10: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RParen"

    // $ANTLR start "Do"
    public void mDo() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Do;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:18:4: ( 'do' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:18:6: 'do'
            {
            	Match("do"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Do"

    // $ANTLR start "For"
    public void mFor() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = For;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:19:5: ( 'for' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:19:7: 'for'
            {
            	Match("for"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "For"

    // $ANTLR start "To"
    public void mTo() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = To;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:20:4: ( 'to' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:20:6: 'to'
            {
            	Match("to"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "To"

    // $ANTLR start "Asign"
    public void mAsign() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Asign;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:21:7: ( ':=' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:21:9: ':='
            {
            	Match(":="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Asign"

    // $ANTLR start "Break"
    public void mBreak() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Break;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:22:7: ( 'break' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:22:9: 'break'
            {
            	Match("break"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Break"

    // $ANTLR start "Let"
    public void mLet() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Let;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:23:5: ( 'let' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:23:7: 'let'
            {
            	Match("let"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Let"

    // $ANTLR start "In"
    public void mIn() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = In;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:24:4: ( 'in' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:24:6: 'in'
            {
            	Match("in"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "In"

    // $ANTLR start "End"
    public void mEnd() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = End;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:25:5: ( 'end' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:25:7: 'end'
            {
            	Match("end"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "End"

    // $ANTLR start "Equal"
    public void mEqual() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Equal;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:26:7: ( '=' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:26:9: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Equal"

    // $ANTLR start "Coma"
    public void mComa() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Coma;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:27:6: ( ',' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:27:8: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Coma"

    // $ANTLR start "PtoComa"
    public void mPtoComa() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PtoComa;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:28:9: ( ';' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:28:11: ';'
            {
            	Match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PtoComa"

    // $ANTLR start "Pto"
    public void mPto() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Pto;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:29:5: ( '.' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:29:7: '.'
            {
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Pto"

    // $ANTLR start "Suma"
    public void mSuma() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Suma;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:30:6: ( '+' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:30:8: '+'
            {
            	Match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Suma"

    // $ANTLR start "Menos"
    public void mMenos() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Menos;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:31:7: ( '-' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:31:9: '-'
            {
            	Match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Menos"

    // $ANTLR start "Mult"
    public void mMult() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Mult;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:32:6: ( '*' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:32:8: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Mult"

    // $ANTLR start "Div"
    public void mDiv() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Div;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:33:5: ( '/' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:33:7: '/'
            {
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Div"

    // $ANTLR start "Distin"
    public void mDistin() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Distin;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:34:8: ( '<>' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:34:10: '<>'
            {
            	Match("<>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Distin"

    // $ANTLR start "Menor"
    public void mMenor() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Menor;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:35:7: ( '<' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:35:9: '<'
            {
            	Match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Menor"

    // $ANTLR start "Mayor"
    public void mMayor() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Mayor;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:36:7: ( '>' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:36:9: '>'
            {
            	Match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Mayor"

    // $ANTLR start "MenorIgual"
    public void mMenorIgual() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MenorIgual;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:37:12: ( '<=' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:37:14: '<='
            {
            	Match("<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MenorIgual"

    // $ANTLR start "MayorIgual"
    public void mMayorIgual() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MayorIgual;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:38:12: ( '>=' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:38:14: '>='
            {
            	Match(">="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MayorIgual"

    // $ANTLR start "And"
    public void mAnd() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = And;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:39:5: ( '&' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:39:7: '&'
            {
            	Match('&'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "And"

    // $ANTLR start "Or"
    public void mOr() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Or;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:40:4: ( '|' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:40:6: '|'
            {
            	Match('|'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Or"

    // $ANTLR start "TypeToken"
    public void mTypeToken() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TypeToken;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:41:11: ( 'type' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:41:13: 'type'
            {
            	Match("type"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TypeToken"

    // $ANTLR start "ArrayOf"
    public void mArrayOf() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ArrayOf;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:42:9: ( 'array of' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:42:11: 'array of'
            {
            	Match("array of"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ArrayOf"

    // $ANTLR start "DOSPTOS"
    public void mDOSPTOS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOSPTOS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:43:9: ( ':' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:43:11: ':'
            {
            	Match(':'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOSPTOS"

    // $ANTLR start "Var"
    public void mVar() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Var;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:44:5: ( 'var' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:44:7: 'var'
            {
            	Match("var"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Var"

    // $ANTLR start "FUNCION"
    public void mFUNCION() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FUNCION;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:45:9: ( 'function' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:45:11: 'function'
            {
            	Match("function"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FUNCION"

    // $ANTLR start "Comilla"
    public void mComilla() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Comilla;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:46:9: ( '\"' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:46:11: '\"'
            {
            	Match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
                
    		finally 
    	{
        }
    }
    // $ANTLR end "Comilla"

    // $ANTLR start "Nil"
    public void mNil() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Nil;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:47:5: ( 'nil' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:47:7: 'nil'
            {
            	Match("nil"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Nil"

    // $ANTLR start "COMMENTS"
    public void mCOMMENTS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENTS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:60:10: ( '/*' ( options {greedy=false; } : COMMENTS | . )* '*/' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:60:11: '/*' ( options {greedy=false; } : COMMENTS | . )* '*/'
            {
            	Match("/*"); 

            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:60:16: ( options {greedy=false; } : COMMENTS | . )*
            	do 
            	{
            	    int alt1 = 3;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == '*') )
            	    {
            	        int LA1_1 = input.LA(2);

            	        if ( (LA1_1 == '/') )
            	        {
            	            alt1 = 3;
            	        }
            	        else if ( ((LA1_1 >= '\u0000' && LA1_1 <= '.') || (LA1_1 >= '0' && LA1_1 <= '\uFFFF')) )
            	        {
            	            alt1 = 2;
            	        }


            	    }
            	    else if ( (LA1_0 == '/') )
            	    {
            	        int LA1_2 = input.LA(2);

            	        if ( (LA1_2 == '*') )
            	        {
            	            alt1 = 1;
            	        }
            	        else if ( ((LA1_2 >= '\u0000' && LA1_2 <= ')') || (LA1_2 >= '+' && LA1_2 <= '\uFFFF')) )
            	        {
            	            alt1 = 2;
            	        }


            	    }
            	    else if ( ((LA1_0 >= '\u0000' && LA1_0 <= ')') || (LA1_0 >= '+' && LA1_0 <= '.') || (LA1_0 >= '0' && LA1_0 <= '\uFFFF')) )
            	    {
            	        alt1 = 2;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:60:43: COMMENTS
            			    {
            			    	mCOMMENTS(); 

            			    }
            			    break;
            			case 2 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:60:54: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop1;
            	    }
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements

            	Match("*/"); 

            	_channel = HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMENTS"

    // $ANTLR start "COMMENTLINE"
    public void mCOMMENTLINE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENTLINE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:62:14: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:62:15: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("//"); 

            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:62:20: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= '\u0000' && LA2_0 <= '\t') || (LA2_0 >= '\u000B' && LA2_0 <= '\f') || (LA2_0 >= '\u000E' && LA2_0 <= '\uFFFF')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:62:20: ~ ( '\\n' | '\\r' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:62:34: ( '\\r' )?
            	int alt3 = 2;
            	int LA3_0 = input.LA(1);

            	if ( (LA3_0 == '\r') )
            	{
            	    alt3 = 1;
            	}
            	switch (alt3) 
            	{
            	    case 1 :
            	        // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:62:34: '\\r'
            	        {
            	        	Match('\r'); 

            	        }
            	        break;

            	}

            	Match('\n'); 
            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMENTLINE"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:64:7: ( ( ' ' | '\\t' | '\\r' | '\\n' )+ )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:64:11: ( ' ' | '\\t' | '\\r' | '\\n' )+
            {
            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:64:11: ( ' ' | '\\t' | '\\r' | '\\n' )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '\t' && LA4_0 <= '\n') || LA4_0 == '\r' || LA4_0 == ' ') )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:
            			    {
            			    	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || input.LA(1) == '\r' || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt4 >= 1 ) goto loop4;
            		            EarlyExitException eee4 =
            		                new EarlyExitException(4, input);
            		            throw eee4;
            	    }
            	    cnt4++;
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "LETTER"
    public void mLETTER() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:66:17: ( 'a' .. 'z' | 'A' .. 'Z' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "LETTER"

    // $ANTLR start "DIGIT"
    public void mDIGIT() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:68:16: ( '0' .. '9' )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:68:18: '0' .. '9'
            {
            	MatchRange('0','9'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT"

    // $ANTLR start "ID"
    public void mID() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ID;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:70:12: ( ( LETTER ( LETTER | DIGIT | '_' )* ) )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:70:14: ( LETTER ( LETTER | DIGIT | '_' )* )
            {
            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:70:14: ( LETTER ( LETTER | DIGIT | '_' )* )
            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:70:15: LETTER ( LETTER | DIGIT | '_' )*
            	{
            		mLETTER(); 
            		// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:70:22: ( LETTER | DIGIT | '_' )*
            		do 
            		{
            		    int alt5 = 2;
            		    int LA5_0 = input.LA(1);

            		    if ( ((LA5_0 >= '0' && LA5_0 <= '9') || (LA5_0 >= 'A' && LA5_0 <= 'Z') || LA5_0 == '_' || (LA5_0 >= 'a' && LA5_0 <= 'z')) )
            		    {
            		        alt5 = 1;
            		    }


            		    switch (alt5) 
            			{
            				case 1 :
            				    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:
            				    {
            				    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;

            				default:
            				    goto loop5;
            		    }
            		} while (true);

            		loop5:
            			;	// Stops C# compiler whining that label 'loop5' has no statements


            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ID"

    // $ANTLR start "CARACT"
    public void mCARACT() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:72:17: (~ ( '\\n' | '\\t' | '\\\\' | '\"' | ' ' ) )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:72:19: ~ ( '\\n' | '\\t' | '\\\\' | '\"' | ' ' )
            {
            	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\b') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\u001F') || input.LA(1) == '!' || (input.LA(1) >= '#' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "CARACT"

    // $ANTLR start "SPACE"
    public void mSPACE() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:74:16: ( ( '\\n' | '\\t' | ' ' ) )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:74:18: ( '\\n' | '\\t' | ' ' )
            {
            	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || input.LA(1) == ' ' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "SPACE"

    // $ANTLR start "ESC"
    public void mESC() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:14: ( ( '\\\\' ) ( SPACE )+ ( '\\\\' ) | ( '\\\\' ) ( 'n' | 't' | '\\\\' | '\"' | ( DIGIT DIGIT DIGIT ) ) )
            int alt8 = 2;
            int LA8_0 = input.LA(1);

            if ( (LA8_0 == '\\') )
            {
                int LA8_1 = input.LA(2);

                if ( ((LA8_1 >= '\t' && LA8_1 <= '\n') || LA8_1 == ' ') )
                {
                    alt8 = 1;
                }
                else if ( (LA8_1 == '\"' || (LA8_1 >= '0' && LA8_1 <= '9') || LA8_1 == '\\' || LA8_1 == 'n' || LA8_1 == 't') )
                {
                    alt8 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d8s1 =
                        new NoViableAltException("", 8, 1, input);

                    throw nvae_d8s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d8s0 =
                    new NoViableAltException("", 8, 0, input);

                throw nvae_d8s0;
            }
            switch (alt8) 
            {
                case 1 :
                    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:16: ( '\\\\' ) ( SPACE )+ ( '\\\\' )
                    {
                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:16: ( '\\\\' )
                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:17: '\\\\'
                    	{
                    		Match('\\'); 

                    	}

                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:23: ( SPACE )+
                    	int cnt6 = 0;
                    	do 
                    	{
                    	    int alt6 = 2;
                    	    int LA6_0 = input.LA(1);

                    	    if ( ((LA6_0 >= '\t' && LA6_0 <= '\n') || LA6_0 == ' ') )
                    	    {
                    	        alt6 = 1;
                    	    }


                    	    switch (alt6) 
                    		{
                    			case 1 :
                    			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:23: SPACE
                    			    {
                    			    	mSPACE(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt6 >= 1 ) goto loop6;
                    		            EarlyExitException eee6 =
                    		                new EarlyExitException(6, input);
                    		            throw eee6;
                    	    }
                    	    cnt6++;
                    	} while (true);

                    	loop6:
                    		;	// Stops C# compiler whining that label 'loop6' has no statements

                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:30: ( '\\\\' )
                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:31: '\\\\'
                    	{
                    		Match('\\'); 

                    	}
                    }
                    break;
                case 2 :
                    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:40: ( '\\\\' ) ( 'n' | 't' | '\\\\' | '\"' | ( DIGIT DIGIT DIGIT ) )
                    {
                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:40: ( '\\\\' )
                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:41: '\\\\'
                    	{
                    		Match('\\'); 

                    	}

                    	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:46: ( 'n' | 't' | '\\\\' | '\"' | ( DIGIT DIGIT DIGIT ) )
                    	int alt7 = 5;
                    	switch ( input.LA(1) ) 
                    	{
                    	case 'n':
                    		{
                    	    alt7 = 1;
                    	    }
                    	    break;
                    	case 't':
                    		{
                    	    alt7 = 2;
                    	    }
                    	    break;
                    	case '\\':
                    		{
                    	    alt7 = 3;
                    	    }
                    	    break;
                    	case '\"':
                    		{
                    	    alt7 = 4;
                    	    }
                    	    break;
                    	case '0':
                    	case '1':
                    	case '2':
                    	case '3':
                    	case '4':
                    	case '5':
                    	case '6':
                    	case '7':
                    	case '8':
                    	case '9':
                    		{
                    	    alt7 = 5;
                    	    }
                    	    break;
                    		default:
                    		    NoViableAltException nvae_d7s0 =
                    		        new NoViableAltException("", 7, 0, input);

                    		    throw nvae_d7s0;
                    	}

                    	switch (alt7) 
                    	{
                    	    case 1 :
                    	        // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:47: 'n'
                    	        {
                    	        	Match('n'); 

                    	        }
                    	        break;
                    	    case 2 :
                    	        // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:51: 't'
                    	        {
                    	        	Match('t'); 

                    	        }
                    	        break;
                    	    case 3 :
                    	        // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:55: '\\\\'
                    	        {
                    	        	Match('\\'); 

                    	        }
                    	        break;
                    	    case 4 :
                    	        // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:60: '\"'
                    	        {
                    	        	Match('\"'); 

                    	        }
                    	        break;
                    	    case 5 :
                    	        // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:64: ( DIGIT DIGIT DIGIT )
                    	        {
                    	        	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:64: ( DIGIT DIGIT DIGIT )
                    	        	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:76:65: DIGIT DIGIT DIGIT
                    	        	{
                    	        		mDIGIT(); 
                    	        		mDIGIT(); 
                    	        		mDIGIT(); 

                    	        	}


                    	        }
                    	        break;

                    	}


                    }
                    break;

            }
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ESC"

    // $ANTLR start "STRING"
    public void mSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:79:8: ( Comilla ( CARACT | SPACE | ESC )* Comilla )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:79:10: Comilla ( CARACT | SPACE | ESC )* Comilla
            {
            	mComilla(); 
            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:79:18: ( CARACT | SPACE | ESC )*
            	do 
            	{
            	    int alt9 = 4;
            	    int LA9_0 = input.LA(1);

            	    if ( ((LA9_0 >= '\u0000' && LA9_0 <= '\b') || (LA9_0 >= '\u000B' && LA9_0 <= '\u001F') || LA9_0 == '!' || (LA9_0 >= '#' && LA9_0 <= '[') || (LA9_0 >= ']' && LA9_0 <= '\uFFFF')) )
            	    {
            	        alt9 = 1;
            	    }
            	    else if ( ((LA9_0 >= '\t' && LA9_0 <= '\n') || LA9_0 == ' ') )
            	    {
            	        alt9 = 2;
            	    }
            	    else if ( (LA9_0 == '\\') )
            	    {
            	        alt9 = 3;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:79:19: CARACT
            			    {
            			    	mCARACT(); 

            			    }
            			    break;
            			case 2 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:79:26: SPACE
            			    {
            			    	mSPACE(); 

            			    }
            			    break;
            			case 3 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:79:32: ESC
            			    {
            			    	mESC(); 

            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	mComilla(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STRING"

    // $ANTLR start "INT"
    public void mINT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:120:5: ( ( DIGIT )+ )
            // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:120:7: ( DIGIT )+
            {
            	// C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:120:7: ( DIGIT )+
            	int cnt10 = 0;
            	do 
            	{
            	    int alt10 = 2;
            	    int LA10_0 = input.LA(1);

            	    if ( ((LA10_0 >= '0' && LA10_0 <= '9')) )
            	    {
            	        alt10 = 1;
            	    }


            	    switch (alt10) 
            		{
            			case 1 :
            			    // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:120:7: DIGIT
            			    {
            			    	mDIGIT(); 

            			    }
            			    break;

            			default:
            			    if ( cnt10 >= 1 ) goto loop10;
            		            EarlyExitException eee10 =
            		                new EarlyExitException(10, input);
            		            throw eee10;
            	    }
            	    cnt10++;
            	} while (true);

            	loop10:
            		;	// Stops C# compiler whining that label 'loop10' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INT"

    override public void mTokens() // throws RecognitionException 
    {
        // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:8: ( LCorch | RCorch | LLlave | RLlave | Of | If | Then | Else | While | LParen | RParen | Do | For | To | Asign | Break | Let | In | End | Equal | Coma | PtoComa | Pto | Suma | Menos | Mult | Div | Distin | Menor | Mayor | MenorIgual | MayorIgual | And | Or | TypeToken | ArrayOf | DOSPTOS | Var | FUNCION | Comilla | Nil | COMMENTS | COMMENTLINE | WS | ID | STRING | INT )
        int alt11 = 47;
        alt11 = dfa11.Predict(input);
        switch (alt11) 
        {
            case 1 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:10: LCorch
                {
                	mLCorch(); 

                }
                break;
            case 2 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:17: RCorch
                {
                	mRCorch(); 

                }
                break;
            case 3 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:24: LLlave
                {
                	mLLlave(); 

                }
                break;
            case 4 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:31: RLlave
                {
                	mRLlave(); 

                }
                break;
            case 5 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:38: Of
                {
                	mOf(); 

                }
                break;
            case 6 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:41: If
                {
                	mIf(); 

                }
                break;
            case 7 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:44: Then
                {
                	mThen(); 

                }
                break;
            case 8 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:49: Else
                {
                	mElse(); 

                }
                break;
            case 9 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:54: While
                {
                	mWhile(); 

                }
                break;
            case 10 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:60: LParen
                {
                	mLParen(); 

                }
                break;
            case 11 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:67: RParen
                {
                	mRParen(); 

                }
                break;
            case 12 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:74: Do
                {
                	mDo(); 

                }
                break;
            case 13 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:77: For
                {
                	mFor(); 

                }
                break;
            case 14 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:81: To
                {
                	mTo(); 

                }
                break;
            case 15 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:84: Asign
                {
                	mAsign(); 

                }
                break;
            case 16 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:90: Break
                {
                	mBreak(); 

                }
                break;
            case 17 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:96: Let
                {
                	mLet(); 

                }
                break;
            case 18 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:100: In
                {
                	mIn(); 

                }
                break;
            case 19 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:103: End
                {
                	mEnd(); 

                }
                break;
            case 20 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:107: Equal
                {
                	mEqual(); 

                }
                break;
            case 21 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:113: Coma
                {
                	mComa(); 

                }
                break;
            case 22 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:118: PtoComa
                {
                	mPtoComa(); 

                }
                break;
            case 23 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:126: Pto
                {
                	mPto(); 

                }
                break;
            case 24 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:130: Suma
                {
                	mSuma(); 

                }
                break;
            case 25 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:135: Menos
                {
                	mMenos(); 

                }
                break;
            case 26 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:141: Mult
                {
                	mMult(); 

                }
                break;
            case 27 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:146: Div
                {
                	mDiv(); 

                }
                break;
            case 28 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:150: Distin
                {
                	mDistin(); 

                }
                break;
            case 29 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:157: Menor
                {
                	mMenor(); 

                }
                break;
            case 30 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:163: Mayor
                {
                	mMayor(); 

                }
                break;
            case 31 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:169: MenorIgual
                {
                	mMenorIgual(); 

                }
                break;
            case 32 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:180: MayorIgual
                {
                	mMayorIgual(); 

                }
                break;
            case 33 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:191: And
                {
                	mAnd(); 

                }
                break;
            case 34 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:195: Or
                {
                	mOr(); 

                }
                break;
            case 35 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:198: TypeToken
                {
                	mTypeToken(); 

                }
                break;
            case 36 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:208: ArrayOf
                {
                	mArrayOf(); 

                }
                break;
            case 37 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:216: DOSPTOS
                {
                	mDOSPTOS(); 

                }
                break;
            case 38 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:224: Var
                {
                	mVar(); 

                }
                break;
            case 39 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:228: FUNCION
                {
                	mFUNCION(); 

                }
                break;
            case 40 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:236: Comilla
                {
                	mComilla(); 

                }
                break;
            case 41 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:244: Nil
                {
                	mNil(); 

                }
                break;
            case 42 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:248: COMMENTS
                {
                	mCOMMENTS(); 

                }
                break;
            case 43 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:257: COMMENTLINE
                {
                	mCOMMENTLINE(); 

                }
                break;
            case 44 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:269: WS
                {
                	mWS(); 

                }
                break;
            case 45 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:272: ID
                {
                	mID(); 

                }
                break;
            case 46 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:275: STRING
                {
                	mSTRING(); 

                }
                break;
            case 47 :
                // C:\\Users\\Grettu\\Mustelier\\Tiger - Alejandro Mustelier (C413) - Pedro A. Laucerica (C413)\\compilador 11.0\\TigerPM_AST.g:1:282: INT
                {
                	mINT(); 

                }
                break;

        }

    }


    protected DFA11 dfa11;
	private void InitializeCyclicDFAs()
	{
	    this.dfa11 = new DFA11(this);
	    this.dfa11.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA11_SpecialStateTransition);
	}

    const string DFA11_eotS =
        "\x05\uffff\x05\x22\x02\uffff\x02\x22\x01\x31\x02\x22\x07\uffff"+
        "\x01\x36\x01\x39\x01\x3b\x02\uffff\x02\x22\x01\x3e\x01\x22\x03\uffff"+
        "\x01\x41\x01\x42\x01\x43\x01\x22\x01\x45\x04\x22\x01\x4a\x02\x22"+
        "\x02\uffff\x02\x22\x08\uffff\x02\x22\x02\uffff\x01\x22\x03\uffff"+
        "\x01\x22\x01\uffff\x02\x22\x01\x55\x01\x22\x01\uffff\x01\x57\x02"+
        "\x22\x01\x5a\x01\x22\x01\x5c\x01\x5d\x01\x5e\x01\x5f\x01\x60\x01"+
        "\uffff\x01\x22\x01\uffff\x02\x22\x01\uffff\x01\x22\x05\uffff\x01"+
        "\x65\x01\x22\x01\x67\x01\x22\x01\uffff\x01\x22\x02\uffff\x01\x22"+
        "\x01\x6b\x01\uffff";
    const string DFA11_eofS =
        "\x6c\uffff";
    const string DFA11_minS =
        "\x01\x09\x04\uffff\x02\x66\x01\x68\x01\x6c\x01\x68\x02\uffff\x02"+
        "\x6f\x01\x3d\x01\x72\x01\x65\x07\uffff\x01\x2a\x02\x3d\x02\uffff"+
        "\x01\x72\x01\x61\x01\x00\x01\x69\x03\uffff\x03\x30\x01\x65\x01\x30"+
        "\x01\x70\x01\x73\x01\x64\x01\x69\x01\x30\x01\x72\x01\x6e\x02\uffff"+
        "\x01\x65\x01\x74\x08\uffff\x02\x72\x02\uffff\x01\x6c\x03\uffff\x01"+
        "\x6e\x01\uffff\x02\x65\x01\x30\x01\x6c\x01\uffff\x01\x30\x01\x63"+
        "\x01\x61\x01\x30\x01\x61\x05\x30\x01\uffff\x01\x65\x01\uffff\x01"+
        "\x74\x01\x6b\x01\uffff\x01\x79\x05\uffff\x01\x30\x01\x69\x01\x30"+
        "\x01\x20\x01\uffff\x01\x6f\x02\uffff\x01\x6e\x01\x30\x01\uffff";
    const string DFA11_maxS =
        "\x01\x7d\x04\uffff\x01\x66\x01\x6e\x01\x79\x01\x6e\x01\x68\x02"+
        "\uffff\x01\x6f\x01\x75\x01\x3d\x01\x72\x01\x65\x07\uffff\x01\x2f"+
        "\x01\x3e\x01\x3d\x02\uffff\x01\x72\x01\x61\x01\uffff\x01\x69\x03"+
        "\uffff\x03\x7a\x01\x65\x01\x7a\x01\x70\x01\x73\x01\x64\x01\x69\x01"+
        "\x7a\x01\x72\x01\x6e\x02\uffff\x01\x65\x01\x74\x08\uffff\x02\x72"+
        "\x02\uffff\x01\x6c\x03\uffff\x01\x6e\x01\uffff\x02\x65\x01\x7a\x01"+
        "\x6c\x01\uffff\x01\x7a\x01\x63\x01\x61\x01\x7a\x01\x61\x05\x7a\x01"+
        "\uffff\x01\x65\x01\uffff\x01\x74\x01\x6b\x01\uffff\x01\x79\x05\uffff"+
        "\x01\x7a\x01\x69\x01\x7a\x01\x20\x01\uffff\x01\x6f\x02\uffff\x01"+
        "\x6e\x01\x7a\x01\uffff";
    const string DFA11_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x05\uffff\x01\x0a\x01"+
        "\x0b\x05\uffff\x01\x14\x01\x15\x01\x16\x01\x17\x01\x18\x01\x19\x01"+
        "\x1a\x03\uffff\x01\x21\x01\x22\x04\uffff\x01\x2c\x01\x2d\x01\x2f"+
        "\x0c\uffff\x01\x0f\x01\x25\x02\uffff\x01\x2a\x01\x2b\x01\x1b\x01"+
        "\x1c\x01\x1f\x01\x1d\x01\x20\x01\x1e\x02\uffff\x01\x28\x01\x2e\x01"+
        "\uffff\x01\x05\x01\x06\x01\x12\x01\uffff\x01\x0e\x04\uffff\x01\x0c"+
        "\x0a\uffff\x01\x13\x01\uffff\x01\x0d\x02\uffff\x01\x11\x01\uffff"+
        "\x01\x26\x01\x29\x01\x07\x01\x23\x01\x08\x04\uffff\x01\x09\x01\uffff"+
        "\x01\x10\x01\x24\x02\uffff\x01\x27";
    const string DFA11_specialS =
        "\x1f\uffff\x01\x00\x4c\uffff}>";
    static readonly string[] DFA11_transitionS = {
            "\x02\x21\x02\uffff\x01\x21\x12\uffff\x01\x21\x01\uffff\x01"+
            "\x1f\x03\uffff\x01\x1b\x01\uffff\x01\x0a\x01\x0b\x01\x17\x01"+
            "\x15\x01\x12\x01\x16\x01\x14\x01\x18\x0a\x23\x01\x0e\x01\x13"+
            "\x01\x19\x01\x11\x01\x1a\x02\uffff\x1a\x22\x01\x01\x01\uffff"+
            "\x01\x02\x03\uffff\x01\x1d\x01\x0f\x01\x22\x01\x0c\x01\x08\x01"+
            "\x0d\x02\x22\x01\x06\x02\x22\x01\x10\x01\x22\x01\x20\x01\x05"+
            "\x04\x22\x01\x07\x01\x22\x01\x1e\x01\x09\x03\x22\x01\x03\x01"+
            "\x1c\x01\x04",
            "",
            "",
            "",
            "",
            "\x01\x24",
            "\x01\x25\x07\uffff\x01\x26",
            "\x01\x27\x06\uffff\x01\x28\x09\uffff\x01\x29",
            "\x01\x2a\x01\uffff\x01\x2b",
            "\x01\x2c",
            "",
            "",
            "\x01\x2d",
            "\x01\x2e\x05\uffff\x01\x2f",
            "\x01\x30",
            "\x01\x32",
            "\x01\x33",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x34\x04\uffff\x01\x35",
            "\x01\x38\x01\x37",
            "\x01\x3a",
            "",
            "",
            "\x01\x3c",
            "\x01\x3d",
            "\x00\x3f",
            "\x01\x40",
            "",
            "",
            "",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x44",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x46",
            "\x01\x47",
            "\x01\x48",
            "\x01\x49",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x4b",
            "\x01\x4c",
            "",
            "",
            "\x01\x4d",
            "\x01\x4e",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x4f",
            "\x01\x50",
            "",
            "",
            "\x01\x51",
            "",
            "",
            "",
            "\x01\x52",
            "",
            "\x01\x53",
            "\x01\x54",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x56",
            "",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x58",
            "\x01\x59",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x5b",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "",
            "\x01\x61",
            "",
            "\x01\x62",
            "\x01\x63",
            "",
            "\x01\x64",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x66",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            "\x01\x68",
            "",
            "\x01\x69",
            "",
            "",
            "\x01\x6a",
            "\x0a\x22\x07\uffff\x1a\x22\x04\uffff\x01\x22\x01\uffff\x1a"+
            "\x22",
            ""
    };

    static readonly short[] DFA11_eot = DFA.UnpackEncodedString(DFA11_eotS);
    static readonly short[] DFA11_eof = DFA.UnpackEncodedString(DFA11_eofS);
    static readonly char[] DFA11_min = DFA.UnpackEncodedStringToUnsignedChars(DFA11_minS);
    static readonly char[] DFA11_max = DFA.UnpackEncodedStringToUnsignedChars(DFA11_maxS);
    static readonly short[] DFA11_accept = DFA.UnpackEncodedString(DFA11_acceptS);
    static readonly short[] DFA11_special = DFA.UnpackEncodedString(DFA11_specialS);
    static readonly short[][] DFA11_transition = DFA.UnpackEncodedStringArray(DFA11_transitionS);

    protected class DFA11 : DFA
    {
        public DFA11(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 11;
            this.eot = DFA11_eot;
            this.eof = DFA11_eof;
            this.min = DFA11_min;
            this.max = DFA11_max;
            this.accept = DFA11_accept;
            this.special = DFA11_special;
            this.transition = DFA11_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( LCorch | RCorch | LLlave | RLlave | Of | If | Then | Else | While | LParen | RParen | Do | For | To | Asign | Break | Let | In | End | Equal | Coma | PtoComa | Pto | Suma | Menos | Mult | Div | Distin | Menor | Mayor | MenorIgual | MayorIgual | And | Or | TypeToken | ArrayOf | DOSPTOS | Var | FUNCION | Comilla | Nil | COMMENTS | COMMENTLINE | WS | ID | STRING | INT );"; }
        }

    }


    protected internal int DFA11_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA11_31 = input.LA(1);

                   	s = -1;
                   	if ( ((LA11_31 >= '\u0000' && LA11_31 <= '\uFFFF')) ) { s = 63; }

                   	else s = 62;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae11 =
            new NoViableAltException(dfa.Description, 11, _s, input);
        dfa.Error(nvae11);
        throw nvae11;
    }
 
    
}
