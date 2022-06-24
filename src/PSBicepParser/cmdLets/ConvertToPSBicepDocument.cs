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
    public PSBicepDocument? DocumentObject { get; set; }

    protected override void ProcessRecord()
    {
        if (DocumentObject == null) { throw new ArgumentNullException(nameof(DocumentObject)); }
        string document = DocumentObject.ConvertToDocument();
        WriteObject(document) ;
    }
}


