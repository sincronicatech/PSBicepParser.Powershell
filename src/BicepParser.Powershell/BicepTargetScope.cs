using System;

namespace BicepParser.Powershell;

public class BicepTargetScope:IBicepElement
{
    public BicepTargetScope(string targetScope)
    {
        Scope = targetScope;
        targetScopeProperty = targetScope;
    }

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
