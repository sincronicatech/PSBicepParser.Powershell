using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell;

public class BicepDocumentVisitor : bicepParserBaseVisitor<PSBicepDocument>
{
    public override PSBicepDocument VisitBicep([NotNull] bicepParser.BicepContext context)
    {
        var document = new PSBicepDocument();

        var targetScopeVisitor = new BicepTargetScopeVisitor();
        if(context.targetScope() != null)
        {
            document.TargetScope = targetScopeVisitor.VisitTargetScope(context.targetScope());
        }

        var paramsContext = context.param();
        document.Params = new PSBicepParam[paramsContext.Length];
        var paramVisitor = new BicepParamVisitor();
        for (int walker = 0; walker < paramsContext.Length; walker++)
        {
            document.Params[walker] = paramVisitor.VisitParam(paramsContext[walker]);
        }

        var resourcesContext = context.resource();
        document.Resources = new PSBicepResource[resourcesContext.Length];
        var resourceVisitor = new BicepResourceVisitor();
        for (int walker = 0; walker < resourcesContext.Length; walker++)
        {
            document.Resources[walker] = resourceVisitor.VisitResource(resourcesContext[walker]);
        }

        var modulesContext = context.module();
        document.Modules = new PSBicepModule[modulesContext.Length];
        var moduleVisitor = new BicepModuleVisitor();
        for (int walker = 0; walker < modulesContext.Length; walker++)
        {
            document.Modules[walker] = moduleVisitor.VisitModule(modulesContext[walker]);
        }

        var outputsContext = context.output();
        document.Outputs = new PSBicepOutput[outputsContext.Length];
        var outputVisitor = new BicepOutputVisitor();
        for (int walker = 0; walker < outputsContext.Length; walker++)
        {
            document.Outputs[walker] = outputVisitor.VisitOutput(outputsContext[walker]);
        }

        return document;
    }

}