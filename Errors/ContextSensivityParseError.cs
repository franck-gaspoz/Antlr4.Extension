using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;

namespace Antrl4.Extension.Errors
{
    public class ContextSensivityParseError
        : ParseErrorAbstract
    {
        public readonly int Prediction;
        public readonly SimulatorState AcceptState;

        public ContextSensivityParseError(
            Antlr4.Runtime.Parser parser,
            DFA dFA,
            int startIndex,
            int stopIndex,
            int prediction, 
            SimulatorState acceptState)
            : base(parser, dFA, startIndex, stopIndex)
        {
            Prediction = prediction;
            AcceptState = acceptState;
        }

        public override string ToString()
        {
            return $"prediction={Prediction} acceptState={AcceptState} {base.ToString()}";
        }
    }
}
