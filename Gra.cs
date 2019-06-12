
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF               =  0, // (EOF)
        SYMBOL_ERROR             =  1, // (Error)
        SYMBOL_WHITESPACE        =  2, // Whitespace
        SYMBOL_MINUS             =  3, // '-'
        SYMBOL_LPAREN            =  4, // '('
        SYMBOL_RPAREN            =  5, // ')'
        SYMBOL_TIMES             =  6, // '*'
        SYMBOL_DOT               =  7, // '.'
        SYMBOL_DIV               =  8, // '/'
        SYMBOL_SEMI              =  9, // ';'
        SYMBOL_LBRACKETDEFAULT   = 10, // '[default'
        SYMBOL_RBRACKET          = 11, // ']'
        SYMBOL_LBRACE            = 12, // '{'
        SYMBOL_LBRACECASE        = 13, // '{case'
        SYMBOL_RBRACE            = 14, // '}'
        SYMBOL_PLUS              = 15, // '+'
        SYMBOL_LT                = 16, // '<'
        SYMBOL_EQ                = 17, // '='
        SYMBOL_GT                = 18, // '>'
        SYMBOL_0                 = 19, // '0'
        SYMBOL_1                 = 20, // '1'
        SYMBOL_2                 = 21, // '2'
        SYMBOL_3                 = 22, // '3'
        SYMBOL_4                 = 23, // '4'
        SYMBOL_5                 = 24, // '5'
        SYMBOL_6                 = 25, // '6'
        SYMBOL_7                 = 26, // '7'
        SYMBOL_8                 = 27, // '8'
        SYMBOL_9                 = 28, // '9'
        SYMBOL_A                 = 29, // a
        SYMBOL_B                 = 30, // b
        SYMBOL_BEGIN             = 31, // begin
        SYMBOL_CASE              = 32, // case
        SYMBOL_DO                = 33, // do
        SYMBOL_ELSE              = 34, // else
        SYMBOL_ENDDO             = 35, // endDo
        SYMBOL_FOR               = 36, // for
        SYMBOL_IDENTIFIER        = 37, // Identifier
        SYMBOL_IF                = 38, // if
        SYMBOL_NEWLINE           = 39, // NewLine
        SYMBOL_STRINGLITERAL     = 40, // StringLiteral
        SYMBOL_SWITCH            = 41, // Switch
        SYMBOL_THEN              = 42, // then
        SYMBOL_VAR               = 43, // var
        SYMBOL_WHILE             = 44, // while
        SYMBOL_Z                 = 45, // z
        SYMBOL_CHAR              = 46, // <Char>
        SYMBOL_CODE              = 47, // <code>
        SYMBOL_DO2               = 48, // <Do>
        SYMBOL_EXPRMINUSCONDTION = 49, // <expr-Condtion>
        SYMBOL_EXPRESSION        = 50, // <Expression>
        SYMBOL_EXPRMINUSOP       = 51, // <expr-op>
        SYMBOL_FLOAT             = 52, // <float>
        SYMBOL_FORMINUSSTMT      = 53, // <for-stmt>
        SYMBOL_IFMINUSSTMT       = 54, // <if-stmt>
        SYMBOL_INT               = 55, // <Int>
        SYMBOL_LOGICALMINUSEXPR  = 56, // <logical-Expr>
        SYMBOL_MIX               = 57, // <Mix>
        SYMBOL_MULTEXP           = 58, // <Mult Exp>
        SYMBOL_NEGATEEXP         = 59, // <Negate Exp>
        SYMBOL_NL                = 60, // <nl>
        SYMBOL_NLOPT             = 61, // <nl Opt>
        SYMBOL_NUM               = 62, // <Num>
        SYMBOL_PROGRAM           = 63, // <Program>
        SYMBOL_START             = 64, // <Start>
        SYMBOL_STMT              = 65, // <stmt>
        SYMBOL_STMTMINUSLIST     = 66, // <stmt-list>
        SYMBOL_SWITCHMINUSSTMT   = 67, // <switch-stmt>
        SYMBOL_TYPE              = 68, // <type>
        SYMBOL_VALUE             = 69, // <Value>
        SYMBOL_VAR2              = 70  // <Var>
    };

    enum RuleConstants : int
    {
        RULE_NL_NEWLINE                                                              =  0, // <nl> ::= NewLine <nl>
        RULE_NL_NEWLINE2                                                             =  1, // <nl> ::= NewLine
        RULE_NLOPT_NEWLINE                                                           =  2, // <nl Opt> ::= NewLine <nl Opt>
        RULE_NLOPT                                                                   =  3, // <nl Opt> ::= 
        RULE_START                                                                   =  4, // <Start> ::= <nl Opt> <Program>
        RULE_PROGRAM                                                                 =  5, // <Program> ::= 
        RULE_NUM_0                                                                   =  6, // <Num> ::= '0'
        RULE_NUM_1                                                                   =  7, // <Num> ::= '1'
        RULE_NUM_2                                                                   =  8, // <Num> ::= '2'
        RULE_NUM_3                                                                   =  9, // <Num> ::= '3'
        RULE_NUM_4                                                                   = 10, // <Num> ::= '4'
        RULE_NUM_5                                                                   = 11, // <Num> ::= '5'
        RULE_NUM_6                                                                   = 12, // <Num> ::= '6'
        RULE_NUM_7                                                                   = 13, // <Num> ::= '7'
        RULE_NUM_8                                                                   = 14, // <Num> ::= '8'
        RULE_NUM_9                                                                   = 15, // <Num> ::= '9'
        RULE_CHAR_A                                                                  = 16, // <Char> ::= a
        RULE_CHAR_B                                                                  = 17, // <Char> ::= b
        RULE_CHAR_Z                                                                  = 18, // <Char> ::= z
        RULE_VAR                                                                     = 19, // <Var> ::= <Char>
        RULE_VAR2                                                                    = 20, // <Var> ::= <Char> <Mix>
        RULE_MIX                                                                     = 21, // <Mix> ::= <Num>
        RULE_MIX2                                                                    = 22, // <Mix> ::= <Char>
        RULE_MIX3                                                                    = 23, // <Mix> ::= <Num> <Mix>
        RULE_MIX4                                                                    = 24, // <Mix> ::= <Char> <Mix>
        RULE_INT                                                                     = 25, // <Int> ::= <Num>
        RULE_INT2                                                                    = 26, // <Int> ::= <Num> <Int>
        RULE_FLOAT                                                                   = 27, // <float> ::= <Int>
        RULE_FLOAT_DOT                                                               = 28, // <float> ::= <Int> '.' <Int>
        RULE_TYPE                                                                    = 29, // <type> ::= <Int>
        RULE_TYPE2                                                                   = 30, // <type> ::= <Char>
        RULE_TYPE3                                                                   = 31, // <type> ::= <float>
        RULE_TYPE_VAR                                                                = 32, // <type> ::= var
        RULE_EXPRESSION_PLUS                                                         = 33, // <Expression> ::= <Expression> '+' <Mult Exp>
        RULE_EXPRESSION_MINUS                                                        = 34, // <Expression> ::= <Expression> '-' <Mult Exp>
        RULE_EXPRESSION                                                              = 35, // <Expression> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                                           = 36, // <Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
        RULE_MULTEXP_DIV                                                             = 37, // <Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
        RULE_MULTEXP_LT                                                              = 38, // <Mult Exp> ::= <Mult Exp> '<' <Negate Exp>
        RULE_MULTEXP_GT                                                              = 39, // <Mult Exp> ::= <Mult Exp> '>' <Negate Exp>
        RULE_MULTEXP                                                                 = 40, // <Mult Exp> ::= <Negate Exp>
        RULE_VALUE_IDENTIFIER                                                        = 41, // <Value> ::= Identifier
        RULE_VALUE_LPAREN_RPAREN                                                     = 42, // <Value> ::= '(' <Expression> ')'
        RULE_NEGATEEXP_MINUS                                                         = 43, // <Negate Exp> ::= '-' <Value>
        RULE_NEGATEEXP                                                               = 44, // <Negate Exp> ::= <Value>
        RULE_IFSTMT_IF_THEN                                                          = 45, // <if-stmt> ::= if <logical-Expr> then <stmt>
        RULE_IFSTMT_IF_THEN_ELSE                                                     = 46, // <if-stmt> ::= if <logical-Expr> then <stmt> else <stmt>
        RULE_LOGICALEXPR                                                             = 47, // <logical-Expr> ::= <Char>
        RULE_STMT                                                                    = 48, // <stmt> ::= <Expression>
        RULE_STMT2                                                                   = 49, // <stmt> ::= <Expression> <if-stmt>
        RULE_STMTLIST                                                                = 50, // <stmt-list> ::= <Expression>
        RULE_SWITCHSTMT_SWITCH_LPAREN_RPAREN_LBRACECASE_THEN_LBRACE_CASE_THEN_RBRACE = 51, // <switch-stmt> ::= Switch '(' <Expression> ')' '{case' <Var> then <stmt-list> '{' case <Var> then <stmt-list> '}'
        RULE_SWITCHSTMT_LBRACKETDEFAULT_RBRACKET_RBRACE                              = 52, // <switch-stmt> ::= '[default' <stmt-list> ']' '}'
        RULE_FORSTMT_FOR_LPAREN_EQ_SEMI_SEMI_RPAREN                                  = 53, // <for-stmt> ::= for '(' <Var> '=' <Num> ';' <expr-Condtion> ';' <expr-op> ')'
        RULE_DO_DO_BEGIN_WHILE_LBRACE_RBRACE_ENDDO                                   = 54, // <Do> ::= do begin <code> while '{' <Expression> '}' endDo
        RULE_CODE_LPAREN_RPAREN                                                      = 55, // <code> ::= '(' ')'
        RULE_CODE_LBRACE_RBRACE                                                      = 56, // <code> ::= '{' <stmt-list> '}'
        RULE_EXPRCONDTION                                                            = 57, // <expr-Condtion> ::= <Expression>
        RULE_EXPROP                                                                  = 58  // <expr-op> ::= <Expression>
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKETDEFAULT :
                //'[default'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACECASE :
                //'{case'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_0 :
                //'0'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_1 :
                //'1'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_2 :
                //'2'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_3 :
                //'3'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_4 :
                //'4'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_5 :
                //'5'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_6 :
                //'6'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_7 :
                //'7'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_8 :
                //'8'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_9 :
                //'9'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_A :
                //a
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_B :
                //b
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENDDO :
                //endDo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //Switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_Z :
                //z
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //<Char>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CODE :
                //<code>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO2 :
                //<Do>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRMINUSCONDTION :
                //<expr-Condtion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRMINUSOP :
                //<expr-op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //<float>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMINUSSTMT :
                //<for-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFMINUSSTMT :
                //<if-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //<Int>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALMINUSEXPR :
                //<logical-Expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MIX :
                //<Mix>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<Negate Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NL :
                //<nl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NLOPT :
                //<nl Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //<Num>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //<Start>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMTMINUSLIST :
                //<stmt-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHMINUSSTMT :
                //<switch-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR2 :
                //<Var>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_NL_NEWLINE :
                //<nl> ::= NewLine <nl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NL_NEWLINE2 :
                //<nl> ::= NewLine
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NLOPT_NEWLINE :
                //<nl Opt> ::= NewLine <nl Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NLOPT :
                //<nl Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_START :
                //<Start> ::= <nl Opt> <Program>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_0 :
                //<Num> ::= '0'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_1 :
                //<Num> ::= '1'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_2 :
                //<Num> ::= '2'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_3 :
                //<Num> ::= '3'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_4 :
                //<Num> ::= '4'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_5 :
                //<Num> ::= '5'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_6 :
                //<Num> ::= '6'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_7 :
                //<Num> ::= '7'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_8 :
                //<Num> ::= '8'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_9 :
                //<Num> ::= '9'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CHAR_A :
                //<Char> ::= a
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CHAR_B :
                //<Char> ::= b
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CHAR_Z :
                //<Char> ::= z
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR :
                //<Var> ::= <Char>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VAR2 :
                //<Var> ::= <Char> <Mix>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MIX :
                //<Mix> ::= <Num>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MIX2 :
                //<Mix> ::= <Char>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MIX3 :
                //<Mix> ::= <Num> <Mix>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MIX4 :
                //<Mix> ::= <Char> <Mix>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INT :
                //<Int> ::= <Num>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INT2 :
                //<Int> ::= <Num> <Int>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FLOAT :
                //<float> ::= <Int>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FLOAT_DOT :
                //<float> ::= <Int> '.' <Int>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<type> ::= <Int>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE2 :
                //<type> ::= <Char>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE3 :
                //<type> ::= <float>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_VAR :
                //<type> ::= var
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUS :
                //<Expression> ::= <Expression> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUS :
                //<Expression> ::= <Expression> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_LT :
                //<Mult Exp> ::= <Mult Exp> '<' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_GT :
                //<Mult Exp> ::= <Mult Exp> '>' <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Negate Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<Negate Exp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<Negate Exp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_THEN :
                //<if-stmt> ::= if <logical-Expr> then <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_THEN_ELSE :
                //<if-stmt> ::= if <logical-Expr> then <stmt> else <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALEXPR :
                //<logical-Expr> ::= <Char>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT :
                //<stmt> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT2 :
                //<stmt> ::= <Expression> <if-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTLIST :
                //<stmt-list> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTMT_SWITCH_LPAREN_RPAREN_LBRACECASE_THEN_LBRACE_CASE_THEN_RBRACE :
                //<switch-stmt> ::= Switch '(' <Expression> ')' '{case' <Var> then <stmt-list> '{' case <Var> then <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTMT_LBRACKETDEFAULT_RBRACKET_RBRACE :
                //<switch-stmt> ::= '[default' <stmt-list> ']' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORSTMT_FOR_LPAREN_EQ_SEMI_SEMI_RPAREN :
                //<for-stmt> ::= for '(' <Var> '=' <Num> ';' <expr-Condtion> ';' <expr-op> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_DO_BEGIN_WHILE_LBRACE_RBRACE_ENDDO :
                //<Do> ::= do begin <code> while '{' <Expression> '}' endDo
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE_LPAREN_RPAREN :
                //<code> ::= '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE_LBRACE_RBRACE :
                //<code> ::= '{' <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRCONDTION :
                //<expr-Condtion> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPROP :
                //<expr-op> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
