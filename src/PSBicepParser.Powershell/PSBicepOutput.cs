using System.Management.Automation;

namespace BicepParser.Powershell;

public class PSBicepOutput: IPSBicepElement
{
    public PSBicepOutput(string identifier, string type, object value)
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
        return $"output {Identifier} {Type} = {PSBicepUtils.Convert(Value)}";
    }
}
