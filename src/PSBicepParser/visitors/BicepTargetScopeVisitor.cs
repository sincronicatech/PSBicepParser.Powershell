using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell
{
    internal class BicepTargetScopeVisitor : bicepParserBaseVisitor<PSBicepTargetScope>
    {
        public override PSBicepTargetScope VisitTargetScope([NotNull] bicepParser.TargetScopeContext context)
        {
            var targetScope = new PSBicepTargetScope(context.scope().GetText());
            
            return targetScope;
        }
    }
}