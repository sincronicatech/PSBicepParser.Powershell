using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BicepParser.Powershell;


public class PSBicepDocument : IPSBicepElement
{
    public PSBicepTargetScope? TargetScope { get; set; }
    public PSBicepParam[] Params { get; set; } = new PSBicepParam[0];
    public PSBicepResource[] Resources { get; set; } = new PSBicepResource[0];

    public PSBicepModule[] Modules { get; set; } = new PSBicepModule[0];
    public PSBicepOutput[] Outputs { get; set; } = new PSBicepOutput[0];
    public IPSBicepObject[] AllObjects
    {
        get
        {
            List<IPSBicepObject> toReturn = new List<IPSBicepObject>();
            toReturn.AddRange(Params);
            toReturn.AddRange(Resources);
            toReturn.AddRange(Modules);
            toReturn.AddRange(Outputs);
            return toReturn.ToArray<IPSBicepObject>();
        }
    }

    public string ElementType => "Document";

    public string ConvertToDocument()
    {
        StringBuilder sb = new StringBuilder();
        if (TargetScope != null)
        {
            sb.AppendLine(TargetScope.ConvertToDocument());
        }
        sb.AppendLine();
        foreach (var param in Params)
        {
            sb.AppendLine(param.ConvertToDocument());
            sb.AppendLine();
        }
        sb.AppendLine();
        foreach (var resource in Resources)
        {
            sb.AppendLine(resource.ConvertToDocument());
            sb.AppendLine();
        }
        foreach (var module in Modules)
        {
            sb.AppendLine(module.ConvertToDocument());
            sb.AppendLine();
        }
        foreach (var output in Outputs)
        {
            sb.AppendLine(output.ConvertToDocument());
        }
        sb.AppendLine();
        return sb.ToString();
    }

    public void Add(IPSBicepObject elementObject){
        var identifier = elementObject.Identifier;
        if(!this.AllObjects.Where<IPSBicepObject>(obj=>obj.Identifier == identifier).Any()){
            switch(elementObject){
                case PSBicepModule module:
                    var listModule = new List<PSBicepModule>(this.Modules){module};
                    this.Modules = listModule.ToArray<PSBicepModule>();
                    break;
                case PSBicepOutput output:
                    var listOutputs = new List<PSBicepOutput>(this.Outputs){output};
                    this.Outputs = listOutputs.ToArray<PSBicepOutput>();
                    break;
                case PSBicepParam parameter:
                    var listParameters = new List<PSBicepParam>(this.Params){parameter};
                    this.Params = listParameters.ToArray<PSBicepParam>();
                    break;
                case PSBicepResource resource:
                    var listResources = new List<PSBicepResource>(this.Resources){resource};
                    this.Resources = listResources.ToArray<PSBicepResource>();
                    break;
            }
        }
        else{
            throw new ArgumentException("Element identifier already in use in the document");
        }
    }

}
