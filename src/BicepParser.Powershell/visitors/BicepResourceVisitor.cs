using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BicepParser.Powershell
{
    internal class BicepResourceVisitor:bicepParserBaseVisitor<BicepResource>
    {
        public override BicepResource VisitResource([NotNull] bicepParser.ResourceContext context)
        {
            var valueParser = new BicepValueVisitor();
            var resourceObject = (System.Collections.Hashtable)valueParser.VisitObjectValue(context.objectValue());

            var name = (string)resourceObject["name"];
            resourceObject.Remove("Name");

            var resource = new BicepResource(context.identifier().GetText(),context.resourceType().GetText(), name);
            if(resourceObject.ContainsKey("parent")){
                var parent = (string)resourceObject["parent"];
                resourceObject.Remove("parent");
                resource.Parent = parent;
            }
            if(resourceObject.ContainsKey("dependsOn")){
                var dependsOn = (object[])resourceObject["dependsOn"];
                resourceObject.Remove("dependsOn");
                resource.DependsOn = dependsOn;
            }

            resource.Attributes=resourceObject;
            return resource;
        }
    }
}