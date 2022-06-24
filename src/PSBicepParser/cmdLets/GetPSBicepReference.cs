using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsCommon.Get, "PSBicepReference")]
[OutputType(typeof(string[]))]
public class GetPSPSBicepReference : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "StringDocument",
        ValueFromPipelineByPropertyName = true)]
    public string? DocumentString { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "PSBicepElement",
        ValueFromPipelineByPropertyName = false)]
    [ValidateNotNullOrEmpty]
    public IPSBicepObject? ElementObject { get; set; }


    protected override void ProcessRecord()
    {
        if(this.ParameterSetName=="PSBicepElement")
        {
            if (ElementObject == null) { throw new ArgumentNullException(nameof(ElementObject)); }
            DocumentString=ElementObject.ConvertToDocument();

        }
        if (DocumentString == null) { throw new ArgumentNullException(nameof(DocumentString)); }

        var references=PSBicepUtils.GetReferences(DocumentString);
        WriteObject(references);
    }
}
