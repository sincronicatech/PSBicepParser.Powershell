using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell
{
    internal class BicepModuleVisitor:bicepParserBaseVisitor<PSBicepModule>
    {
        public override PSBicepModule VisitModule([NotNull] bicepParser.ModuleContext context)
        {
            var valueParser = new BicepValueVisitor();
            var moduleObject = (System.Collections.Hashtable)valueParser.VisitObjectValue(context.objectValue());
            
            var name = (string)moduleObject["name"];
            moduleObject.Remove("Name");
            
            var module = new PSBicepModule(context.identifier().GetText(),context.modulePath().GetText(), name);
            
            module.Attributes=moduleObject;
            return module;
        }
    }
}