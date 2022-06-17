using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsData.ConvertTo, "PSBicepDocument")]
[OutputType(typeof(string))]
public class ConvertToBicepDocument : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true)]
    public PSBicepDocument? InputObject { get; set; }

    protected override void ProcessRecord()
    {
        if (InputObject == null) { throw new ArgumentNullException(nameof(InputObject)); }
        string document = InputObject.ConvertToDocument();
        WriteObject(document) ;
    }
}


