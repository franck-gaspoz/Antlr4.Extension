using Antlr4.Runtime;
using System;

namespace Antrl4.Extension
{
    /// <summary>
    /// rule expression parser sharable component
    /// </summary>
    public class LexerParser
    {
        static LexerParser _Instance;
        public static LexerParser Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new LexerParser();
                return _Instance;
            }
        }

        protected LexerParser() { }

        public ParseResult<LexerType, ParserType>
            Parse<LexerType,ParserType>(
                string text,
                ICSTToASTTransformer cSTToASTTransformer = null,
                int rootRuleIndex = 0
            )
            where LexerType : Lexer
            where ParserType : Parser
        {
            var result = new ParseResult<LexerType, ParserType>();
            try
            {
                var antlrInputStream = new AntlrInputStream(text);
                result.AntlrInputStream = antlrInputStream;
                var lexer = (LexerType)Activator.CreateInstance(typeof(LexerType), new object[] { antlrInputStream });
                result.Lexer = lexer;
                var commonTokenStream = new CommonTokenStream(lexer);
                result.CommonTokenStream = commonTokenStream;
                var parser = (ParserType)Activator.CreateInstance(typeof(ParserType), new object[] { commonTokenStream });
                result.Parser = parser;
                parser.RemoveErrorListeners();
                var parseErrorListener =
                    new ParserErrorListener(true);
                parser.AddErrorListener(
                    parseErrorListener
                    );
                result.ParseErrorListener = parseErrorListener;
                var rootRuleName = parser.RuleNames[rootRuleIndex];
                var rootRuleMethodInfo =
                    parser.GetType().GetMethod(rootRuleName);

                var parseTree = (ParserRuleContext)rootRuleMethodInfo
                    .Invoke(parser, new object[] { });
                result.ParseTree = parseTree;

                if (cSTToASTTransformer != null)
                {
                    result.CSTToASTTransformer = cSTToASTTransformer;
                    cSTToASTTransformer.Transform(parseTree);
                }

            } catch (Exception ex)
            {
                result.LexerParserUnhandledException = ex;
            }
            return result;
        }
    }
}
