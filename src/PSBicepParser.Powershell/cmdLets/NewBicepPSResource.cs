using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.Generic;

namespace BicepParser.Powershell;

[Cmdlet(VerbsCommon.New, "PSBicepResource")]
[OutputType(typeof(PSBicepResource))]
public class NewBicepResource : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0)]
    public string? Identifier { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 1)]
    public string? ResourceType { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 2)]
    public string? Name { get; set; }

    [Parameter(
        Mandatory = false,
        Position = 3)]
    public string? Parent { get; set; }

    [Parameter(
        Mandatory = false,
        Position = 4)]
    public string[] DependsOn { get; set; } = new string[0];

    [Parameter(
        Mandatory = false)]
    public bool IsExisting { get; set; } = false;


    protected override void ProcessRecord()
    {
        if (Identifier == null) { throw new ArgumentNullException(nameof(Identifier)); }
        if (ResourceType == null) { throw new ArgumentNullException(nameof(ResourceType)); }
        if (Name == null) { throw new ArgumentNullException(nameof(Name)); }
        var resource = new PSBicepResource(Identifier, ResourceType, Name);
        if (Parent != null)
        {
            resource.Parent = Parent;
        }
        if (DependsOn.Length != 0)
        {
            resource.DependsOn = (string[])DependsOn.Clone();
        }
        if (IsExisting)
        {
            resource.IsExisting = true;
        }
    }


}



