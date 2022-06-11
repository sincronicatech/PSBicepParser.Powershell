using System.Management.Automation;

namespace BicepParser.Powershell;

public class BicepOutput: IBicepElement
{
    public BicepOutput(string identifier, string type, object value)
    {
        Identifier = identifier;
        Type = type;
        Value = value;
    }

    public object Value { get; set; }
    public string Identifier { get; }
    public string Type { get; }

    public string ConvertToDocument()
    {
        return $"output {Identifier} {Type} = {BicepUtils.Convert(Value)}";
    }
}
