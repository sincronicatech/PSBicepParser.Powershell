using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsCommon.New, "PSBicepOutput")]
[OutputType(typeof(PSBicepOutput))]
public class NewBicepOutput : PSCmdlet
{

    [Parameter(
        Mandatory = true,
        Position = 0)]
    public string? Identifier { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 1)]
    [ValidateSet("string", "bool", "int", "array", "object")]
    public string? Type { get; set; } = "Dog";


    [Parameter(
        Mandatory = true,
        Position = 2)]
    public PSObject? Value { get; set; }

    protected override void ProcessRecord()
    {
        if (Identifier == null) { throw new ArgumentNullException(nameof(Identifier)); }
        if (Type == null) { throw new ArgumentNullException(nameof(Type)); }
        if (Value == null) { throw new ArgumentNullException(nameof(Value)); }

        var output = new PSBicepOutput(Identifier, Type,Value);

        WriteObject(
            output
        );
    }
}


