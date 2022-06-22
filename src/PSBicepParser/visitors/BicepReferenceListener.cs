using System.Collections.Generic;
using Antlr4.Runtime.Misc;

namespace BicepParser.Powershell
{
    internal class BicepReferenceVisitor: bicepParserBaseVisitor<int>
    {
        public ISet<string> references = new HashSet<string>();

        public override int VisitReference([NotNull] bicepParser.ReferenceContext context)
        {
            references.Add(context.identifier().GetText());
            return 0;
        }

    }
}