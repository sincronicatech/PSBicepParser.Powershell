using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BicepParser.Powershell;

[Cmdlet(VerbsCommon.New, "BicepDocument")]
[OutputType(typeof(BicepDocument))]
public class NewBicepDocument : PSCmdlet
{

    protected override void ProcessRecord()
    {
        WriteObject(new BicepDocument());
    }
}
