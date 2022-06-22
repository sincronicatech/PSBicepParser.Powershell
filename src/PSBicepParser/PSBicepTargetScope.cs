using System;

namespace BicepParser.Powershell;

public class PSBicepTargetScope: IPSBicepElement
{
    public PSBicepTargetScope(string targetScope)
    {
        Scope = targetScope;
        targetScopeProperty = targetScope;
    }

    public string ElementType => "TargetScope";

    private string targetScopeProperty;
    public string Scope
    {
        get
        {
            return targetScopeProperty;
        }
        set
        {
            switch (value)
            {
                case "resourceGroup":
                case "subscription":
                case "managementGroup":
                case "tenant":
                    targetScopeProperty = value;
                    break;
                default:
                    throw new ArgumentException($"Value {value} not valid for target scope");
            }
        }
    }
    public string ConvertToDocument()
    {
        return $"targetScope = {Scope}";
    }


}
