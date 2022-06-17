using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsData.ConvertFrom, "PSBicepDocument")]
[OutputType(typeof(PSBicepDocument))]
public class ConvertFromPSBicepDocument : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true)]
    public string? DocumentString { get; set; }



    protected override void ProcessRecord()
    {
        if (DocumentString == null) { throw new ArgumentNullException(nameof(DocumentString)); }
        PSBicepDocument document = PSBicepUtils.Parse(DocumentString);
        WriteObject(document);

    }


}


