using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell
{
    internal class BicepOutputVisitor:bicepParserBaseVisitor<BicepOutput>
    {
        public override BicepOutput VisitOutput([NotNull] bicepParser.OutputContext context)
        {
            var value = (new BicepValueVisitor()).VisitValue(context.value());
            var output = new BicepOutput(context.identifier().GetText(),context.type().GetText(), value);
            
            return output;
        }
    }
}