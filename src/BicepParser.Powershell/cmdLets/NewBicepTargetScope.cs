using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsCommon.New, "BicepTargetScope")]
[OutputType(typeof(BicepTargetScope))]
public class NewBicepTargetScope : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0)]
    [ValidateSet("resourceGroup", "subscription", "managementGroup", "tenant")]
    public string? Scope { get; set; }

    protected override void ProcessRecord()
    {
        if (Scope == null)
        {
            throw new ArgumentNullException(nameof(Scope));
        }
        WriteObject(new BicepTargetScope(Scope));
    }

}



