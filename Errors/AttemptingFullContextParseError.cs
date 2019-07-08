using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Sharpen;

namespace Antrl4.Extension.Errors
{
    public class AttemptingFullContextParseError
        : ParseErrorAbstract
    {
        public readonly BitSet ConflictingAlts;
        public readonly SimulatorState ConfictState;

        public AttemptingFullContextParseError(
            Antlr4.Runtime.Parser parser,
            DFA dFA,
            int startIndex,
            int stopIndex,
            BitSet conflictingAlts, 
            SimulatorState confictState)
            : base(parser, dFA, startIndex, stopIndex)
        {
            ConflictingAlts = conflictingAlts;
            ConfictState = confictState;
        }

        public override string ToString()
        {
            return $" {base.ToString()}";
        }
    }
}
