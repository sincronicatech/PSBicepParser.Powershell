using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell
{
    internal class BicepParamVisitor : bicepParserBaseVisitor<PSBicepParam>
    {
        public override PSBicepParam VisitParam([NotNull] bicepParser.ParamContext context)
        {

            var param =  new PSBicepParam(context.identifier().GetText(),context.type().GetText());
            if(context.value()!=null){
                var valueVisitor = new BicepValueVisitor();
                param.DefaultValue = valueVisitor.VisitValue(context.value());
            }
            var decoratorsContext = context.decorator();
            string[] decorators = new string[decoratorsContext.Length];
            for(int walker = 0; walker < decoratorsContext.Length; walker++)
            {
                decorators[walker]= decoratorsContext[walker].valueExpression().GetText();
            }
            param.Decorators = decorators;

            return param;
        }


    }
}