using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

    [Cmdlet(VerbsCommon.New, "BicepModule")]
[OutputType(typeof(BicepModule))]
public class NewBicepModule : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0)]
    public string? Identifier { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 1)]
    public string? ModulePath { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 2)]
    public string? Name { get; set; }


    protected override void ProcessRecord()
    {
        if (Identifier == null) { throw new ArgumentNullException(nameof(Identifier)); }
        if (ModulePath == null) { throw new ArgumentNullException(nameof(ModulePath)); }
        if (Name == null) { throw new ArgumentNullException(nameof(Name)); }
        var module = new BicepModule(Identifier, ModulePath, Name);

    }


}



