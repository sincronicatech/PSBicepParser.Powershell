using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsData.ConvertFrom, "BicepDocument")]
[OutputType(typeof(BicepDocument))]
public class ConvertFromBicepDocument : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true)]
    public string? InputObject { get; set; }



    protected override void ProcessRecord()
    {
        if (InputObject == null) { throw new ArgumentNullException(nameof(InputObject)); }
        BicepDocument document = BicepUtils.Parse(InputObject);
        WriteObject(document);

    }


}


