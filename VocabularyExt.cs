using Antlr4.Runtime;
using System;

namespace Antrl4.Extension
{
    public static class VocabularyExt
    {
        public static string GetLiteral(this Vocabulary vocabulary, int tokenType)
        {
            var s = vocabulary.GetLiteralName(tokenType);
            s = s.Substring(1, s.Length - 2);
            return s;
        }

        public static string GetSymbol(this Vocabulary vocabulary, int tokenType)
        {
            var s = vocabulary.GetSymbolicName(tokenType);
            return s;
        }

        public static int GetTokenType(this Vocabulary vocabulary, string literal)
        {
            var n = vocabulary.MaxTokenType;
            for (int i = 0; i <= n; i++)
                if (vocabulary.GetLiteralName(i)
                    == $"'{literal}'")
                    return i;
            throw new Exception($"unknown literal name: {literal}");
        }
    }
}
