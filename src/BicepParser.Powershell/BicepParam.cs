using System.Management.Automation;

namespace BicepParser.Powershell;
public class BicepParam:IBicepElement
{
    public BicepParam(string identifier, string type)
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
            toReturn += $" = {BicepUtils.Convert(DefaultValue)}";
        }
        return toReturn;
    }
}
