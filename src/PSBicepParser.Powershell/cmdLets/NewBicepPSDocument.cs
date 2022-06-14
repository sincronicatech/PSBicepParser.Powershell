using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsCommon.New, "PSBicepDocument")]
[OutputType(typeof(PSBicepDocument))]
public class NewBicepDocument : PSCmdlet
{

    protected override void ProcessRecord()
    {
        WriteObject(new PSBicepDocument());
    }
}
