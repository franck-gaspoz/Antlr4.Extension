using Antlr4.Runtime.Dfa;

namespace Antrl4.Extension.Errors
{
    public abstract class ParseErrorAbstract
    {
        public readonly Antlr4.Runtime.Parser Parser;
        public readonly DFA DFA;
        public int StartIndex { get; protected set; }
        public int StopIndex { get; protected set; }

        protected ParseErrorAbstract(
            Antlr4.Runtime.Parser parser, 
            DFA dFA, 
            int startIndex, 
            int stopIndex)
        {
            Parser = parser;
            DFA = dFA;
            StartIndex = startIndex;
            StopIndex = stopIndex;
        }

        public override string ToString()
        {
            return $"startIndex={StartIndex} stopIndex={StopIndex}";
        }
    }
}
