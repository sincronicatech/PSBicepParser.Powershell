using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell
{
    internal class BicepModuleVisitor:bicepParserBaseVisitor<BicepModule>
    {
        public override BicepModule VisitModule([NotNull] bicepParser.ModuleContext context)
        {
            var valueParser = new BicepValueVisitor();
            var moduleObject = (System.Collections.Hashtable)valueParser.VisitObjectValue(context.objectValue());
            
            var name = (string)moduleObject["name"];
            moduleObject.Remove("Name");
            
            var module = new BicepModule(context.identifier().GetText(),context.modulePath().GetText(), name);
            
            module.Attributes=moduleObject;
            return module;
        }
    }
}