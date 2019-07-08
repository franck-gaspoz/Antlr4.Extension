using Antlr4.Runtime;
using System;

namespace Antrl4.Extension
{
    public class ParseResult<LexerType,ParserType>
        where LexerType : Lexer
        where ParserType : Parser
    {
        public AntlrInputStream AntlrInputStream;
        public LexerType Lexer;
        public ParserType Parser;
        public CommonTokenStream CommonTokenStream;
        public ICSTToASTTransformer CSTToASTTransformer;
        public ParserRuleContext ParseTree;
        public object ASTTree
        {
            get
            {
                return CSTToASTTransformer?.ASTTree;
            }
        }

        public Exception LexerParserUnhandledException;

        public ParserErrorListener ParseErrorListener;

        /// <summary>
        /// true if at least one error or an unhandled exception after tried parsing
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return ParseErrorListener.HasErrors || LexerParserUnhandledException!=null;
            }
        }

        public ParseResult() { }        
    }
}
