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
    public string? StringDocument { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "PSBicepElement",
        ValueFromPipelineByPropertyName = false)]
    [ValidateNotNullOrEmpty]
    public IPSBicepObject? PSBicepElement { get; set; }


    protected override void ProcessRecord()
    {
        if(this.ParameterSetName=="PSBicepElement")
        {
            if (PSBicepElement == null) { throw new ArgumentNullException(nameof(PSBicepElement)); }
            StringDocument=PSBicepElement.ConvertToDocument();

        }
        if (StringDocument == null) { throw new ArgumentNullException(nameof(StringDocument)); }

        var references=PSBicepUtils.GetReferences(StringDocument);
        WriteObject(references);
    }
}
