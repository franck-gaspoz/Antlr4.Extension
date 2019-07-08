using Antlr4.Runtime;

namespace Antrl4.Extension.Errors
{
    public class SyntaxErrorParseError
        : ParseErrorAbstract
    {
        public readonly IRecognizer Recognizer;
        public readonly IToken OffendingSymbol;
        public readonly int Line;
        public readonly int CharPositionLine;
        public readonly string Message;
        public readonly RecognitionException RecognitionException;

        public SyntaxErrorParseError(            
            IRecognizer recognizer, 
            IToken offendingSymbol, 
            int line, 
            int charPositionLine, 
            string message, 
            RecognitionException recognitionException)
            : base(null, null, -1, -1)
        {
            Recognizer = recognizer;
            OffendingSymbol = offendingSymbol;
            Line = line;
            CharPositionLine = charPositionLine;
            Message = message;
            RecognitionException = recognitionException;
            StartIndex = OffendingSymbol.StartIndex;
            StopIndex = OffendingSymbol.StopIndex;
        }

        public override string ToString()
        {
            return $"offendingSymbol={OffendingSymbol} line={Line} charPositionLine={CharPositionLine} message={Message} recognitionException={RecognitionException} {base.ToString()}";
        }
    }
}
