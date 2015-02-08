grammar TigerPM_Sola;

options
{
language=CSharp;
}

tokens
{
LCorch='[';
RCorch=']';
LLlave='{';
RLlave='}';
Of='of';
If='if';
Then='then';
Else='else';
While='while';
LParen='(';
RParen=')';
Do='do';
For='for';
To='to';
Asign=':=';
Break='break';
Let='let';
In='in';
End='end';
Equal='=';
Coma=',';
PtoComa=';';
Pto='.';
Suma='+';
Menos='-';
Mult='*';
Div='/';
Distin='<>';
Menor='<';
Mayor='>';
MenorIgual='<=';
MayorIgual='>=';
And='&';
Or='|';
TypeToken='type';
ArrayOf='array of';
DOSPTOS=':';
Var='var';
FUNCION='function';
Comilla='"';
Nil='nil';
}


COMMENTS	:'/*' (options {greedy=false;} : COMMENTS | .)* '*/' {$channel = HIDDEN;} ;	
COMMENTLINE 	:'//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;};
WS 	 	:   ( ' ' | '\t' | '\r' | '\n' )+ {$channel=HIDDEN;} ;

fragment LETTER	:	'a'..'z'|'A'..'Z';
fragment DIGIT	:	'0'..'9';


ID	        : (LETTER (LETTER|DIGIT|'_')* );


fragment CARACT	:	~('\n'|'\t'|'\\'|'"'|' ');
fragment SPACE	:	('\n'|'\t'|' ');
fragment ESC	:	('\\')('n'|'t'|'\\'|'"');


STRING	:	Comilla (CARACT|SPACE|ESC)* Comilla;


operador:	MayorIgual| MenorIgual|	Mayor| Menor| Distin| Equal;	


INT :	DIGIT+;

prog	:	exp EOF;

exp	:	expAnd (Or exp)?;

expAnd	:	expRelac(And expAnd)?; 

expRelac:	expArit(operador expRelac)?;
                               
                
expArit	:	term(Suma term| Menos term)*;

term	:	fact(Mult fact|Div fact)*;

fact	:	STRING 
		| INT
		| Nil   
		| Menos exp 
		| LParen exp_Seq RParen factAux
		| ID    ( LLlave field_List RLlave factAux
			| LParen exp_List RParen factAux  
			| (LCorch exp RCorch Of)=>LCorch exp RCorch Of exp
			| (Pto ID | LCorch exp RCorch)* (Asign exp)?)
		| If exp Then exp (Else exp)?  
		| Break 
		| While exp Do exp
		| For ID Asign exp To exp Do exp
		| Let declaration_List In exp_Seq End factAux ;

factAux: 	(Pto ID | LCorch exp RCorch)*;

exp_List:	(exp(Coma exp)*)?;

exp_Seq	:	(exp(PtoComa exp)*)?;

//type_Id	:	'int' | 'string' | ID;

field_List	
	:	ID Equal exp(Coma ID Equal exp)*;

declaration_List
	:	declaration+;	

declaration
	:	type_Declaration | variable_Declaration | function_Declaration;
	
type_Declaration
	:	TypeToken ID Equal type;
	
type	:	ID | LLlave type_Fields RLlave | ArrayOf ID;


type_Fields
	:	(ID DOSPTOS ID ( Coma ID DOSPTOS ID )*)? ;	
	
//type_Field
//	:	ID DOSPTOS ID;
	
variable_Declaration
	:	Var ID Asign exp | Var ID DOSPTOS ID Asign exp;
	
function_Declaration
	:	 FUNCION ID LParen type_Fields RParen (DOSPTOS ID)? Equal exp;



	


	
