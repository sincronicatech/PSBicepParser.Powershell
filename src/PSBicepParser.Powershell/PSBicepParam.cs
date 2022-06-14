using System.Management.Automation;

namespace BicepParser.Powershell;
public class PSBicepParam:IPSBicepElement
{
    public PSBicepParam(string identifier, string type)
    {
        Identifier = identifier;
        Type = type;
    }

    public string Identifier { get; }
    public string Type { get; }
    public object? DefaultValue { get; internal set; }

    public string[] Decorators { get; internal set; } = new string[0];

    public string ConvertToDocument()
    { 
        string toReturn="";
        foreach(var decorator in Decorators)
        {
            toReturn+= "@" + decorator + System.Environment.NewLine;
        }
        toReturn += $"param {Identifier} {Type}";
        if(DefaultValue!= null){
            toReturn += $" = {PSBicepUtils.Convert(DefaultValue)}";
        }
        return toReturn;
    }
}
