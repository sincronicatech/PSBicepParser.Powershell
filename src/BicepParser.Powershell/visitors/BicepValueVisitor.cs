using System.Collections;
using System.Management.Automation;
using Antlr4.Runtime.Misc;

namespace BicepParser.Powershell
{
    internal class BicepValueVisitor:bicepParserBaseVisitor<object>
    {

        public override object VisitStringValue([NotNull] bicepParser.StringValueContext context)
        {
            return context.GetText();
        }

        public override object VisitNumberValue([NotNull] bicepParser.NumberValueContext context)
        {
            return int.Parse(context.GetText());
        }

        public override object VisitBoolValue([NotNull] bicepParser.BoolValueContext context)
        {
            return bool.Parse(context.GetText());
        }

        public override object VisitValueExpression([NotNull] bicepParser.ValueExpressionContext context)
        {
            return context.GetText();
        }

        public override object VisitArrayValue([NotNull] bicepParser.ArrayValueContext context)
        {
            
            var values = context.value();
            var toReturn = new object[values.Length];
            for(int walker = 0; walker< values.Length; walker++)
            {
                toReturn[walker]=this.Visit(values[walker]);
            }
            return toReturn;
        }

        public override object VisitObjectValue([NotNull] bicepParser.ObjectValueContext context)
        {
            var toReturn = new Hashtable();
            var properties = context.property();
            var propertyVisitor = new BicepPropertyVisitor();
            for(int walker = 0; walker< properties.Length; walker++)
            {
                (string propertyName, object propertyValue)= propertyVisitor.VisitProperty(properties[walker]);
                toReturn.Add(propertyName, propertyValue);
                
            }
            return toReturn;
        }
    }
}