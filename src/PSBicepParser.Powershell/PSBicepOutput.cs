using System.Management.Automation;

namespace BicepParser.Powershell;

public class PSBicepOutput: IPSBicepObject
{
    public PSBicepOutput(string identifier, string type, object value)
    {
        Identifier = identifier;
        Type = type;
        Value = value;
    }

    public object Value { get; set; }
    public string Identifier { get; set; }
    public string Type { get; set; }

    public string ElementType => "Output";

    public string ConvertToDocument()
    {
        return $"output {Identifier} {Type} = {PSBicepUtils.Convert(Value)}";
    }
}
