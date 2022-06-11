using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell
{
    internal class BicepTargetScopeVisitor : bicepParserBaseVisitor<BicepTargetScope>
    {
        public BicepTargetScopeVisitor()
        {
        }
    }
}