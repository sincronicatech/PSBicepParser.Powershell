using Antlr4.Runtime.Misc;

namespace BicepParser.Powershell
{
    internal class BicepPropertyVisitor:bicepParserBaseVisitor<(string,object)>
    {
        public override (string, object) VisitProperty([NotNull] bicepParser.PropertyContext context)
        {
            string propertyName = context.propertyName().GetText();
            var valueVisitor = new BicepValueVisitor();
            object propertyValue = valueVisitor.VisitValue(context.value());
            return (propertyName,propertyValue);
        }
    }
}