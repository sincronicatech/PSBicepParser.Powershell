using System.Collections.Generic;
using System.Text;

namespace BicepParser.Powershell;


public class BicepDocument:IBicepElement{
    public BicepTargetScope? TargetScope {get;set;}
    public BicepParam[] Params {get; set;} = new BicepParam[0];
    public BicepResource[] Resources {get; set;} = new BicepResource[0];

    public BicepModule[] Modules {get; set; } = new BicepModule[0];
    public BicepOutput[] Outputs {get; set;} = new BicepOutput[0];

    public string ConvertToDocument()
    {
        StringBuilder sb = new StringBuilder();
        if(TargetScope != null){
            sb.AppendLine(TargetScope.ConvertToDocument());
        }
        sb.AppendLine();
        foreach(var param in Params)
        {
            sb.AppendLine(param.ConvertToDocument());
            sb.AppendLine();
        }
        sb.AppendLine();
        foreach(var resource in Resources){
            sb.AppendLine(resource.ConvertToDocument());
            sb.AppendLine();
        }
        foreach(var module in Modules){
            sb.AppendLine(module.ConvertToDocument());
            sb.AppendLine();
        }
        foreach(var output in Outputs)
        {
            sb.AppendLine(output.ConvertToDocument());
        }
        sb.AppendLine();
        return sb.ToString();
    }

}
