using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;

namespace Antrl4.Extension.Errors
{
    public class AmbiguityParseError
        : ParseErrorAbstract
    {
        public readonly bool Exact;
        public readonly BitSet AmbigAlts;
        public readonly ATNConfigSet Configs;

        public AmbiguityParseError(
            Antlr4.Runtime.Parser parser,
            DFA dFA,
            int startIndex,
            int stopIndex,
            bool exact,
            BitSet ambigAlts,
            ATNConfigSet configs)
            : base(parser, dFA, startIndex, stopIndex)
        {
            Exact = exact;
            AmbigAlts = ambigAlts;
            Configs = configs;
        }

        public override string ToString()
        {
            return $"configs={Configs} ambigAlts={AmbigAlts} {base.ToString()}";
        }
    }
}
