using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;
using Antrl4.Extension.Errors;
using System;
using System.ComponentModel;

namespace Antrl4.Extension
{
    /// <summary>
    /// antlr custom error listener
    /// </summary>
    public class ParserErrorListener
        : BaseErrorListener
    {
        readonly bool _LogEnabled = false;

        public BindingList<ParseErrorAbstract> Errors
            = new BindingList<ParseErrorAbstract>();

        /// <summary>
        /// true if at least one error after parse
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return Errors.Count > 0;
            }
        }

        /// <summary>
        /// build custom error listener. log and store errors in Errors
        /// </summary>
        /// <param name="LogEnabled">if true, dump errors on standard output,debug output</param>
        public ParserErrorListener(bool LogEnabled)
        {
            _LogEnabled = LogEnabled;
            Errors.ListChanged += (o, e) =>
            {
                if (e.ListChangedType==ListChangedType.ItemAdded)
                {
                    var msg = Errors[e.NewIndex] + "";
                    Console.WriteLine(msg);
                    System.Diagnostics.Debug.WriteLine(msg);
                }
            };
        }
        
        public void ClearErrors()
        {
            Errors.Clear();
        }

        public override void ReportAmbiguity(
            [NotNull] Antlr4.Runtime.Parser recognizer, 
            [NotNull] DFA dfa, 
            int startIndex, 
            int stopIndex, 
            bool exact, 
            [Nullable] BitSet ambigAlts, 
            [NotNull] ATNConfigSet configs)
        {
            Errors.Add(
                new AmbiguityParseError(recognizer, dfa, startIndex, stopIndex, exact, ambigAlts, configs)
            );
        }

        public override void ReportAttemptingFullContext(
            [NotNull] Antlr4.Runtime.Parser recognizer, 
            [NotNull] DFA dfa, 
            int startIndex, 
            int stopIndex, 
            [Nullable] BitSet conflictingAlts, 
            [NotNull] SimulatorState conflictState)
        {
            Errors.Add(
                new AttemptingFullContextParseError(recognizer, dfa, startIndex, stopIndex, conflictingAlts, conflictState)
            );
        }

        public override void ReportContextSensitivity(
            [NotNull] Antlr4.Runtime.Parser recognizer, 
            [NotNull] DFA dfa, 
            int startIndex, 
            int stopIndex, 
            int prediction, 
            [NotNull] SimulatorState acceptState)
        {
            Errors.Add(
                new ContextSensivityParseError(recognizer, dfa, startIndex, stopIndex, prediction, acceptState)
            );
        }

        public override void SyntaxError(
            [NotNull] IRecognizer recognizer, 
            [Nullable] IToken offendingSymbol, 
            int line, 
            int charPositionInLine, 
            [NotNull] string message, 
            [Nullable] RecognitionException recognitionException)
        {
            Errors.Add(
                new SyntaxErrorParseError(recognizer, offendingSymbol, line, charPositionInLine, message, recognitionException)
            );
        }
    }
}
