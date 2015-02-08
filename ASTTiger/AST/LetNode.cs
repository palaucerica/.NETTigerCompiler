using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;

namespace ASTTiger
{
    public class LetNode : ControlNode
    {
        public List<DeclarationNode> Decl { get; private set; }
        public ExpSeqNode expSec { get; private set; }
        TypeReturn resulLet; //El resultado del Let(Lo que devuelve)

        public LetNode(List<DeclarationNode> decl, List<LanguageNode> body)
        {
            Decl = decl;
            expSec = new ExpSeqNode(body);
        }

        public override TypeReturn CheckSemantics(List<Scope> scope_list, List<Error> errors)
        {
            int cantCiclo = countOfClicles;
            countOfClicles = 0;

            scope_list.Add(new Scope());

            for (int i = 0; i < Decl.Count; i++)
            {
                if (Decl[i] is FunDeclarationNode)//ver si es una declaración de funnción
                    i = CheckFuntion(i, scope_list, errors);//ver si es un bloque de funciones
                else
                {
                    if (Decl[i] is TypeDeclarationNode)//ver si es una declaración de tipo                    
                        i = CheckType(i, scope_list, errors);

                    else Decl[i].CheckSemantics(scope_list, errors);//si es una declaración de variable 
                }
            }

            countOfClicles = cantCiclo;

            resulLet = expSec.CheckSemantics(scope_list, errors); //hago el checksemantics del exp-sec;            
            scope_list.RemoveAt(scope_list.Count - 1);

            return resulLet;
        }

        //-----------------------chequea el bloque de funcioenes
        int CheckFuntion(int first, List<Scope> scope_list, List<Error> errors)
        {
            int last = first;
            List<int> FunMalHeader = new List<int>();//poniendo            

            //---------------------cojo las funciones------------------------------------------
            for (int i = first; i < Decl.Count; i++)
            {
                last = i;
                if (Decl[i] is FunDeclarationNode)
                {
                    if (((FunDeclarationNode)Decl[i]).CheckHeader(scope_list, errors))
                        FunMalHeader.Add(i);//poniendo    
                }
                else
                {
                    last = i - 1;
                    break;
                }
            }
            //----------------------------------------------------------------

            for (int i = first; i <= last; i++)
            {
                if (FunMalHeader.Contains(i)) continue;
                Decl[i].CheckSemantics(scope_list, errors);//chequeo el cuerpo de la función 
            }

            return last;
        }

        //---------------------chequea el bloque de tipos
        int CheckType(int first, List<Scope> scope_list, List<Error> errors)
        {
            int last = first;
            Dictionary<string, string> tem = new Dictionary<string, string>();//guardo todos los nombres de los tipos
            List<TypeDeclarationNode> no_recursive_types = new List<TypeDeclarationNode>();//guardo solo los alias y los arrays que no pueden caer en un ciclo         
            Dictionary<string, TypeDeclarationNode> typ = new Dictionary<string, TypeDeclarationNode>();//guardo los que no son alias

            for (int i = first; i < Decl.Count; i++)
            {
                last = i;
                if (Decl[i] is TypeDeclarationNode)
                {
                    string name = ((TypeDeclarationNode)Decl[i]).Id;//cojo el nombre del type 

                    if (Utils.IsSystemType(name))
                        errors.Add(new Error(Decl[i].line, Decl[i].column, "No se puede crear un tipo con el nombre de 'int' o de 'string'"));
                    else if (scope_list[scope_list.Count - 1].Types.ContainsKey(name) || tem.ContainsKey(name)) //ver si hay un tipo con ese nombre.
                        errors.Add(new Error(Decl[i].line, Decl[i].column, "Existe un tipo con el nombre " + "'" + name + "'"));
                    else
                    {
                        if (Decl[i] is AliasDecNode || Decl[i] is ArrayDecNode) no_recursive_types.Add((TypeDeclarationNode)Decl[i]);//Añado el alias o array en su lista
                        else typ.Add(name, (TypeDeclarationNode)Decl[i]);//Añado el TypeDeclarationNode en su diccionario
                        tem.Add(name, name);//añado el nombre de cada tipo
                    }
                }
                else
                {
                    last = i - 1;
                    break;
                }
            }
 
            //--------chequeo los ciclos en los alias o arrays
            int cant = 0;
            while (cant != no_recursive_types.Count())//verificar que los alias esten correctos
            {
                cant = no_recursive_types.Count();
                for (int i = 0; i < no_recursive_types.Count; i++)
                {
                    if (no_recursive_types[i] is AliasDecNode)
                    {
                        var t = Utils.FindType(scope_list, ((AliasDecNode)no_recursive_types[i]).Value_redef);//me dice si el tipo existe y me lo dá
                        if (t != null)
                        {
                            scope_list[scope_list.Count() - 1].Types.Add(no_recursive_types[i].Id, t);
                            no_recursive_types.Remove(no_recursive_types[i]);//lo quito de la lista de alias
                            i = i - 1;
                        }
                        else
                        {
                            if (typ.ContainsKey(((AliasDecNode)no_recursive_types[i]).Value_redef))
                            {
                                typ.Add(no_recursive_types[i].Id, typ[((AliasDecNode)no_recursive_types[i]).Value_redef]);
                                no_recursive_types.Remove(no_recursive_types[i]);
                                i = i - 1;
                            }
                        }
                    }
                    else if (no_recursive_types[i] is ArrayDecNode)
                    {
                        var t = Utils.FindType(scope_list, ((ArrayDecNode)no_recursive_types[i]).Value);//me dice si el tipo existe y me lo dá
                        if (t != null)
                        {
                            scope_list[scope_list.Count() - 1].Types.Add(no_recursive_types[i].Id, new ReturnArray(no_recursive_types[i].Id, t));
                            no_recursive_types.Remove(no_recursive_types[i]);//lo quito de la lista de alias
                            i = i - 1;
                        }
                        else
                        {
                            if (typ.ContainsKey(((ArrayDecNode)no_recursive_types[i]).Value))
                            {
                                typ.Add(no_recursive_types[i].Id, no_recursive_types[i]);
                                no_recursive_types.Remove(no_recursive_types[i]);
                                i = i - 1;
                            }
                        }
                    }
                }
            }

            if (no_recursive_types.Count() > 0)//hay ciclo o error
                for (int i = 0; i < no_recursive_types.Count(); i++)
                {
                    if (no_recursive_types[i] is ArrayDecNode)
                        errors.Add(new Error(no_recursive_types[i].line, no_recursive_types[i].column, "El array '" + no_recursive_types[i].Id + "' es recursivo , es mutuamente recursivo o su tipo es invalido"));
                    else
                        errors.Add(new Error(no_recursive_types[i].line, no_recursive_types[i].column, "Error en el alias el tipo no pasa a traves de ningún record o array"));
                }

            //---ver si estan bien
            cant = 0;
            while (cant != typ.Count())
            {
                cant = typ.Count();
                foreach (var t in typ)
                {
                    if (t.Key != t.Value.Id)//es un alias
                    {
                        var temp = (scope_list[scope_list.Count - 1].Types.ContainsKey(t.Value.Id)) ? scope_list[scope_list.Count - 1].Types[t.Value.Id] : null;
                        if (temp != null)// era un alias al que ya resolvi su tipo
                        {
                            scope_list[scope_list.Count - 1].Types.Add(t.Key, temp);
                            typ.Remove(t.Key);//lo quito de la lista del diccionario typ
                            break;
                        }
                        else if (!typ.ContainsKey(t.Value.Id))//Es imposible resolver el alias pues el tipo al que hace referencia dio error al resolverse
                        {
                            errors.Add(new Error(t.Value.line, t.Value.column, "No se pudo resolver el alias '" + t.Key + "'"));
                            typ.Remove(t.Key);//lo quito de la lista del diccionario typ
                            break;
                        }
                        continue;
                    }
                    if (t.Value is ArrayDecNode)//si es una declaración de Array
                    {
                        var v = Utils.FindType(scope_list, ((ArrayDecNode)t.Value).Value);
                        if (v != null)
                        {
                            scope_list[scope_list.Count() - 1].Types.Add(t.Key, new ReturnArray(t.Value.Id, v));
                            typ.Remove(t.Key);//lo quito de la lista del diccionario typ
                            break;
                        }
                        else
                        {
                            if (!typ.ContainsKey(((ArrayDecNode)t.Value).Value))
                            {
                                errors.Add(new Error(t.Value.line, t.Value.column, "No existe el tipo con el nombre " + "'" + ((ArrayDecNode)t.Value).Value + "'"));
                                typ.Remove(t.Key);//lo quito de la lista de typ
                                break;
                            }
                        }
                    }
                    if (t.Value is RecordDecNode)//si es una declaración de Record
                    {
                        int entro = 0;
                        var params_record = new List<Tuple<string, TypeReturn>>();//guardo los campos de los record

                        foreach (var par in ((RecordDecNode)t.Value).Value)//recorro los campos de los record
                        {
                            var v = Utils.FindType(scope_list, par.Item2);//veo el tipo de cada record

                            if (v != null)//si existe el tipo  
                            {
                                params_record.Add(new Tuple<string, TypeReturn>(par.Item1, v));//añado el campo con su tipo
                                continue;
                            }
                            else
                            {
                                entro = 1;
                                if (!typ.ContainsKey(par.Item2))
                                {
                                    errors.Add(new Error(t.Value.line, t.Value.column, "No existe el tipo con el nombre " + "'" + par.Item2 + "'"));
                                    typ.Remove(t.Key);//lo quito de la lista de typ
                                    entro = 2;
                                    break;
                                }
                            }
                        }

                        if (entro == 0)//No hay ningún conflicto con los tipos, todos estan en el scope
                        {
                            var aux = new ReturnRecord(t.Value.Id, params_record);
                            scope_list[scope_list.Count() - 1].Types.Add(t.Key, aux);//Añado al Scope
                            (t.Value as RecordDecNode).record = aux; //lo guardo para usarlo en la generacion de codigo
                            typ.Remove(t.Key);//lo quito de la lista de alias                               
                            break;
                        }
                        if (entro == 2) break;//es porque modifique y estoy haciendo un foreach
                    }
                }
            }

            List<Tuple<string, string>> toRemove = new List<Tuple<string, string>>(); //borrar los alias que estan bien antes de llenar los tipo recursivos por ultima vez
            foreach (var t in typ)//recorro los que quedan en typ y lleno al diccionario "type_scope" 
            {
                if (t.Key != t.Value.Id)//Es un alias
                {
                    toRemove.Add(new Tuple<string, string>(t.Key, t.Value.Id));
                    continue;
                }
                if (t.Value is RecordDecNode)
                {
                    ReturnRecord aux = new ReturnRecord(t.Value.Id, new List<Tuple<string, TypeReturn>>());
                    scope_list[scope_list.Count - 1].Types.Add(t.Key, aux); //la lista de los campos esta vacia
                    (t.Value as RecordDecNode).record = aux; //lo guardo para usarlo en la generacion de codigo
                }
                if (t.Value is ArrayDecNode)
                    scope_list[scope_list.Count - 1].Types.Add(t.Key, new ReturnArray(t.Value.Id, null));//el tipo del array no se conoce
            }

            while (toRemove.Count > 0)//quito los alias los meto en el scope con el type return del tipo a que hacen referencia.
            {
                var temp = toRemove[toRemove.Count - 1];
                scope_list[scope_list.Count - 1].Types.Add(temp.Item1, scope_list[scope_list.Count - 1].Types[temp.Item2]);
                toRemove.Remove(temp);
                typ.Remove(temp.Item1);
            }

            foreach (var t in typ)//llenamos lo que esta en "type_scope" que no se conoce 
            {
                if (t.Value is RecordDecNode)
                {
                    foreach (var elem in ((RecordDecNode)t.Value).Value)//recorro para llenar los campos del record
                    {
                        TypeReturn x = Utils.FindType(scope_list, elem.Item2);//pido su tipo                       
                        ((ReturnRecord)scope_list[scope_list.Count - 1].Types[t.Key]).Fields.Add(new Tuple<string, TypeReturn>(elem.Item1, x));
                    }
                }
                if (t.Value is ArrayDecNode)
                    ((ReturnArray)scope_list[scope_list.Count - 1].Types[t.Key]).Type_Of_Elements =
                        scope_list[scope_list.Count - 1].Types[((ArrayDecNode)t.Value).Value];//lleno el tipo del array
            }
            return last;
        }

        public override Type GenCode(ILGenerator ilGenerator, TypeBuilder parent, FieldBuilder IsBreakFields, List<FieldBuilder> level, Label endLabel)
        {
            //Defino el tipo let como una clase anidada
            TypeBuilder let = parent.DefineNestedType("Let" + Utils.AutoNumeric, TypeAttributes.NestedPublic | TypeAttributes.Class);

            foreach (var dec in Decl)
            {
                if (dec is RecordDecNode) (dec as RecordDecNode).CreateType();
                if (dec is FunDeclarationNode) (dec as FunDeclarationNode).CreateType(let);
            }

            //Guardo las variables
            List<VarDeclarationNode> varib = new List<VarDeclarationNode>();

            //esto es para la declarando el campo que tendrá la referencia al padre al padre 
            FieldBuilder fieldPare = let.DefineField("parent", parent, FieldAttributes.Public);
            level.Add(fieldPare);

            foreach (var dec in Decl)
            {
                if (dec is VarDeclarationNode) varib.Add((dec as VarDeclarationNode));

                //Genero codigo de los record
                if (dec is RecordDecNode) (dec as RecordDecNode).GenCode();               
            }            

            //Creo el constructor         
            ConstructorBuilder letCrt = let.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,new List<Type>() { parent }.ToArray());
            ILGenerator ilCrt = letCrt.GetILGenerator();

            //esto es para la referencia al padre           
            ilCrt.Emit(OpCodes.Ldarg_0); //meto el this
            ilCrt.Emit(OpCodes.Ldarg_1);//meto el padre en la pila
            ilCrt.Emit(OpCodes.Stfld, fieldPare);
           

            //Crear las variables dentro de la clase let y asignarle el valor
            for (int i = 0; i < varib.Count; i++)            
                varib[i].GenCode(ilCrt, let,IsBreakFields,level, endLabel);

            FieldBuilder field = let.DefineField("Break", typeof(bool), FieldAttributes.Public);
            ilCrt.Emit(OpCodes.Ldarg_0); //meto el this
            ilCrt.Emit(OpCodes.Ldc_I4_0); //meto un cero en la pila
            ilCrt.Emit(OpCodes.Stfld, field);    

            //Cerrar el constructor
            ilCrt.Emit(OpCodes.Ret);

            foreach (var dec in Decl)
                //Genero codigo de la funcion
                if (dec is FunDeclarationNode) (dec as FunDeclarationNode).GenCode(null, let, default(FieldBuilder), level, default(Label));

            //Creo el metodo en el que se encuentra el body
            Type res = (resulLet is ReturnNil) ? typeof(object) : resulLet.MyType();
            MethodBuilder mLet = let.DefineMethod("BodyLet", MethodAttributes.Public, CallingConventions.HasThis,res , new Type[] { });
            ILGenerator ilMet = mLet.GetILGenerator();

            Label endLet = ilMet.DefineLabel();

            expSec.GenCode(ilMet, let,field,level, endLet);

            ilMet.MarkLabel(endLet);

            ilMet.Emit(OpCodes.Ldarg_0);
            ilMet.Emit(OpCodes.Ldfld, fieldPare);

            //meto en la pila el valor del break
            ilMet.Emit(OpCodes.Ldarg_0);
            ilMet.Emit(OpCodes.Ldfld, field);            
            ilMet.Emit(OpCodes.Stfld, IsBreakFields);

            ilMet.Emit(OpCodes.Ret);                        

            // Crear el tipo que representa al Let.
            let.CreateType();

            level.RemoveAt(level.Count - 1);

            // Crear una instancia del tipo que representa al Let.
            ilGenerator.Emit(OpCodes.Ldarg_0);            
            ilGenerator.Emit(OpCodes.Newobj, letCrt);

            // Llamar al método que representa el cuerpo del Let.
             ilGenerator.Emit(OpCodes.Callvirt, mLet);

             return (resulLet is ReturnNotValue) ? null : res;
        }
    }
}
