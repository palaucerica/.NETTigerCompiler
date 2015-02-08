grammar TigerPM_AST;

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

@header
{
using ASTTiger;
using System.Collections.Generic;
}

COMMENTS	:'/*' (options {greedy=false;} : COMMENTS | .)* '*/' {$channel = HIDDEN;} ;	

COMMENTLINE 	:'//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;};

WS 	 	:   ( ' ' | '\t' | '\r' | '\n' )+ {$channel=HIDDEN;} ;

fragment LETTER	:	'a'..'z'|'A'..'Z';

fragment DIGIT	:	'0'..'9';

ID	        : (LETTER (LETTER|DIGIT|'_')* );

fragment CARACT	:	~('\n'|'\t'|'\\'|'"'|' ');

fragment SPACE	:	('\n'|'\t'|' ');

fragment ESC	:	('\\') SPACE+ ('\\') |  ('\\')('n'|'t'|'\\'|'"'|(DIGIT DIGIT DIGIT));


STRING	:	Comilla (CARACT|SPACE|ESC)* Comilla;


oprelac returns [string value,int line ,int column]		:	
                                                 MayorIgual
                                                 {
                                                  	$value=$MayorIgual.Text;
                                                   	$line=$MayorIgual.line;
						   	$column=$MayorIgual.CharPositionInLine;
                                                 }
						| MenorIgual
						{
						   	$value=$MenorIgual.Text;
						   	$line=$MenorIgual.line;
						  	$column=$MenorIgual.CharPositionInLine;
						}
						| Mayor
						{
						   	$value=$Mayor.Text;
						   	$line=$Mayor.line;
						  	$column=$Mayor.CharPositionInLine;
						}
						| Menor
						{
							$value=$Menor.Text;
							$line=$Menor.line;
						  	$column=$Menor.CharPositionInLine;
						}
						| Distin
						{
							$value=$Distin.Text;
							$line=$Distin.line;
						  	$column=$Distin.CharPositionInLine;
						}
						| Equal
						{
							$value=$Equal.Text;
							$line=$Equal.line;
						  	$column=$Equal.CharPositionInLine;
						} ;

INT :	DIGIT+;

//-------------------------------------------------------------------------------------------------------------------------

prog returns [LanguageNode root]	:	exp EOF{$root = $exp.root;};


exp returns [LanguageNode root] 	:	left=expAnd {$root = $left.root;}
						(Or right=exp 
						       {
						  	  $root = new OrNode($left.root,$right.root);
						  	  $root.line=$Or.line;
						  	  $root.column=$Or.CharPositionInLine;						  	  					  	  	
						       }
						)?;
						

expAnd returns [LanguageNode root]	:	left=expRelac {$root = $left.root;}
						(And right=expAnd
								{
								  $root =new AndNode($left.root,$right.root);
								  $root.line=$And.line;
						  	          $root.column=$And.CharPositionInLine;
								}
						)?;
						

expRelac returns [LanguageNode root]    :	left=expArit{$root = $left.root;}
						(oprelac right=expRelac
								{
								  switch($oprelac.value)
								  {
								   case "=":
								   {
								     $root=new EqualsNode($left.root,$right.root);								     
								     break;
								   }
								   
								   case "<>":
								   {
								     $root=new DistinctNode($left.root,$right.root);
								     break;
								   }
								   
								   case "<":
								   {
								     $root=new LessThanNode($left.root,$right.root);
								     break;
								   }
								   
								   case ">":
								   {
								     $root=new GreaterThanNode($left.root,$right.root);
								     break;
								   }
								   
								   case "<=":
								   {
								     $root=new LessThanEqualsNode($left.root,$right.root);
								     break;
								   }
								   
								    case ">=":
								   {
								     $root=new GreaterThanEqualNode($left.root,$right.root);
								     break;
								   }
								   								   
								  }
								  $root.line=$oprelac.line;
						  	          $root.column=$oprelac.column;								  
								}
						)?;					
						
						                    
                
expArit returns [LanguageNode root]	:   left =term {$root = $left.root;} (
							Suma rightSum =term 
							{
								$root=new PlusNode($root,$rightSum.root);
								$root.line=$Suma.line;
						  	  	$root.column=$Suma.CharPositionInLine;	
							}
							|Menos rightRes =term
							{
								$root=new MinusNode($root,$rightRes.root);
								$root.line=$Menos.line;
						  	  	$root.column=$Menos.CharPositionInLine;
							}							
							)*;					
						
						

term  returns [LanguageNode root]       :	left=fact{$root = $left.root;}
						(Mult rightMul=fact
								{
								  $root=new MultNode($root,$rightMul.root);
								  $root.line=$Mult.line;
						  	  	  $root.column=$Mult.CharPositionInLine;
								}
						|Div rightDiv=fact
								{
								  $root=new DivNode($root,$rightDiv.root);
								  $root.line=$Div.line;
						  	  	  $root.column=$Div.CharPositionInLine;
								}
						)*;				
						
						

fact returns [LanguageNode root]	:	STRING{$root=new StringNode($STRING.Text);} 
						| integer=INT{$root=new IntNode($integer.Text);}						
						| Nil{$root=new NilNode();}  						 
						| Menos unary_exp=exp
						        {
						           $root=new NegativeOperationNode($unary_exp.root);
						           $root.line=$Menos.line;
						      	   $root.column=$Menos.CharPositionInLine;
						        }						
						| LParen ex_seq=exp_Seq RParen {$root=new ExpSeqNode($ex_seq.list);} (acces=factAux{$root=new AccessNode($root,$acces.access_list);})?
						              {
							         $root.line=$RParen.line;
						      	         $root.column=$RParen.CharPositionInLine;
						      	      }
						
						| id=ID    ( LLlave list_val=field_List RLlave{$root=new RecordCreate($id.Text,$list_val.dict);} (acces=factAux {$root=new AccessNode($root,$acces.access_list);})?
						             {
							           $root.line=$ID.line;
						      	           $root.column=$ID.CharPositionInLine;
						      	      }
						
							   | LParen param=exp_List RParen{$root=new FuntionCall($param.list,$id.Text);} (acces=factAux{$root=new AccessNode($root,$acces.access_list);})? 
							      {
							           $root.line=$ID.line;
						      	           $root.column=$ID.CharPositionInLine;
						      	      }
							   
							   | (LCorch exp RCorch Of)=>LCorch size=exp RCorch Of initial=exp
							      {
							         $root=new ArrayCreate($id.Text,$size.root,$initial.root);
							         $root.line=$ID.line;
						      		 $root.column=$ID.CharPositionInLine;
							      }
							   
							   | {$root=new VariableNode($id.Text);}(acces=factAux
							        {$root=new AccessNode($root,$acces.access_list);})? 
							        {
							           $root.line=$ID.line;
						      		   $root.column=$ID.CharPositionInLine;
							        }							            
							      (Asign val=exp
							      {
							        $root=new AsignNode($root,$val.root);
							        $root.line=$Asign.line;
						      		$root.column=$Asign.CharPositionInLine;
							      })?)
							   
						| If cond1=exp Then body_if=exp 
						    {$root=new IfThenNode($cond1.root,$body_if.root);}
						     (Else body_else=exp {$root=new IfThenElseNode($cond1.root,$body_if.root,$body_else.root);} )? 
						     {
						       $root.line=$If.line;
						       $root.column=$If.CharPositionInLine;
						     } 
						| Break 
						   {
						      $root=new BreakNode();
						      $root.line=$Break.line;
						      $root.column=$Break.CharPositionInLine;
						   }
						| While conditional=exp Do body=exp 
						  {
						     $root=new WhileNode($conditional.root,$body.root);
						     $root.line=$While.line;
						     $root.column=$While.CharPositionInLine;
						  }
						| For name=ID Asign asign=exp To conditional=exp Do increment=exp 
						   {
						     $root=new ForNode($name.Text,$asign.root,$conditional.root,$increment.root);
						     $root.line=$For.line;
						     $root.column=$For.CharPositionInLine;
						   }
						| Let declaration_list=declaration_List In body_list=exp_Seq End {$root=new LetNode($declaration_list.list,$body_list.list);}
						 (acces=factAux {$root=new AccessNode($root,$acces.access_list);})? ;

factAux returns [List<Access> access_list] 	@init{access_list=new List<Access>();}     
	 : 	(Pto id=ID {
	            $access_list.Add(new AccessPto($id.Text,$Pto.line,$Pto.CharPositionInLine));	            
		 } 
	 	| LCorch index=exp RCorch {$access_list.Add(new AccessIndex($index.root,$LCorch.line,
	 	$LCorch.CharPositionInLine));} )+;


exp_List  returns [List<LanguageNode> list]   @init{list=new List<LanguageNode>();}
	 :	(exp1=exp {list.Add($exp1.root);} 
	 	(Coma exp2=exp {list.Add($exp2.root);})*)?;

exp_Seq	 returns[List<LanguageNode> list]  @init{list=new List<LanguageNode>();}
	:	(exp1=exp {list.Add($exp1.root);}
		(PtoComa exp2=exp {list.Add($exp2.root);}) *)?;

field_List	returns[List<Tuple<string,LanguageNode>> dict]	  @init{dict=new List<Tuple<string,LanguageNode>>();}
	:	id=ID Equal exp_asign=exp	{$dict.Add(new Tuple<string, LanguageNode>($id.Text,$exp_asign.root));}
		 (Coma id1=ID Equal exp_asign1=exp {$dict.Add(new Tuple<string, LanguageNode>($id1.Text,$exp_asign1.root));} )*;

declaration_List returns[List<DeclarationNode> list] @init{list=new List<DeclarationNode>();}
	:	(dec=declaration{$list.Add($dec.res);} )+;	

declaration returns[DeclarationNode res]
	:	type1=type_Declaration {$res=$type1.type_dec;}
	 	| variable=variable_Declaration {$res=$variable.var_dec;} 
	 	| function=function_Declaration {$res=$function.fun_dec;};
	
type_Declaration returns[TypeDeclarationNode type_dec]
	:	TypeToken id1=ID Equal type1=type 
	        {
	         $type_dec=$type1.type_dec;
	         $type_dec.Id = $id1.Text;
	         $type_dec.line=$Equal.line;
		 $type_dec.column=$Equal.CharPositionInLine;} ;
	
type	returns[TypeDeclarationNode type_dec]
	:	id=ID {$type_dec=new AliasDecNode($id.Text);}
		 | LLlave list=type_Fields RLlave {$type_dec=new RecordDecNode($list.ids);} 
		 | ArrayOf id1=ID {$type_dec=new ArrayDecNode($id1.Text);};

type_Fields	returns[List<Tuple<string,string>> ids]	@init{ids=new List<Tuple<string,string>>();}
	:	(id1=ID DOSPTOS id2=ID {$ids.Add(new Tuple<string,string>($id1.Text,$id2.Text));}
		 ( Coma id3=ID DOSPTOS id4=ID  {$ids.Add(new Tuple<string,string>($id3.Text,$id4.Text));} )*)? ;	
	
variable_Declaration returns[VarDeclarationNode var_dec]
	:	Var id1=ID Asign expAsign=exp {var_dec=new VarDeclarationNode($id1.Text,$expAsign.root);
	                $var_dec.line=$Asign.line;
		        $var_dec.column=$Asign.CharPositionInLine;}
	| 	Var id2=ID DOSPTOS id3=ID Asign expAsign1=exp 
	        {var_dec=new VarDeclarationNode($id2.Text,$id3.Text,$expAsign1.root);
	          $var_dec.line=$Asign.line;
		  $var_dec.column=$Asign.CharPositionInLine;}; 
	
function_Declaration returns[FunDeclarationNode fun_dec]
	:	 FUNCION name=ID LParen param=type_Fields RParen {$fun_dec=new ProcedureDeclarationNode($name.Text,$param.ids);} 
		(DOSPTOS ret=ID {$fun_dec=new FunctionNode($name.Text,$param.ids,$ret.Text);} )? 
	 	Equal body=exp 
	 	{
	 	  $fun_dec.Body=$body.root;
                  $fun_dec.line=$Equal.line;
                  $fun_dec.column=$Equal.CharPositionInLine;};
	


