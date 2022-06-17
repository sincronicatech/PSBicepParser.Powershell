using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsDiagnostic.Resolve, "PSBicepReference")]
[OutputType(typeof(string[]))]
public class ResolvePSPSBicepReference : PSCmdlet
{
    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = false,
        ValueFromPipelineByPropertyName = true)]
    public string? Identifier { get; set; }

    [Parameter(
        Mandatory = true,
        Position = 1,
        ValueFromPipeline = false,
        ValueFromPipelineByPropertyName = true)]
    public PSBicepDocument? Document { get; set; }

    private IPSBicepObject? findElement(string identifier, IPSBicepObject[] elements)
    {
        foreach(var element in elements){
            if(element.Identifier == identifier){
                return element;
            }
        }
        return null;
    }
    protected override void ProcessRecord()
    {
        if (Identifier == null) { throw new ArgumentNullException(nameof(Identifier)); }
        if (Document == null) { throw new ArgumentNullException(nameof(Document)); }
        
        foreach(var element in Document.AllObjects){
            if(element.Identifier == Identifier){
                WriteObject( element); return;
            }
        }

    }
}
