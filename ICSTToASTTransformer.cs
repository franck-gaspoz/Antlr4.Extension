using Antlr4.Runtime;

namespace Antrl4.Extension
{
    public interface ICSTToASTTransformer
    {
        object ASTTree { get; }

        object Transform(ParserRuleContext parseTreeRoot);
    }
}
