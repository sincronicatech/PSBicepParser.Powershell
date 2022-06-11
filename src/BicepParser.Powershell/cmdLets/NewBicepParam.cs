using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsCommon.New, "BicepParam")]
[OutputType(typeof(BicepParam))]
public class NewBicepParam : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0)]
    public string? Identifier { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 1)]
    [ValidateSet("string", "bool", "int", "array", "object")]
    public string? Type { get; set; }


    [Parameter(
        Mandatory = false,
        Position = 2)]
    public PSObject? DefaultValue { get; set; }

    protected override void ProcessRecord()
    {
        if (Identifier == null) { throw new ArgumentNullException(nameof(Identifier)); }
        if (Type == null) { throw new ArgumentNullException(nameof(Type)); }
        var paramValue = new BicepParam(Identifier, Type);
        if (DefaultValue != null)
        {
            paramValue.DefaultValue = DefaultValue;
        }

        WriteObject(paramValue);
    }

}


