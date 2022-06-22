using System.Collections;
using System.Collections.Generic;

namespace BicepParser.Powershell;

public class PSBicepResource:IPSBicepObject
{
    public PSBicepResource(string identifier, string resourceType, string name)
    {
        Identifier = identifier;
        ResourceType = resourceType;
        Name = name;
    }

    public string Identifier { get; set; }
    public string ResourceType { get; set; }
    public string Name { get; set; }
    public string? Parent { get; set; }
    public object[] DependsOn { get; set; } = new object[0];
    public bool IsExisting { get; set; } = false;

    public string ElementType => "Resource";

    private Hashtable attributes = new Hashtable();
    public Hashtable Attributes { 
        get{
            return attributes;
        }
        set{
            attributes = (Hashtable)value.Clone();
            if(attributes.ContainsKey("name")){
                Name = (string)attributes["name"];
                attributes.Remove("name");
            }
            if(attributes.ContainsKey("parent")){
                Parent = (string)attributes["parent"];
                attributes.Remove("parent");
            }
            if(attributes.ContainsKey("dependsOn")){
                DependsOn = (object[])attributes["dependsOn"];
                attributes.Remove("dependsOn");
            }
        }
    }

    public string ConvertToDocument()
    {
        var newHashtable = (Hashtable)Attributes.Clone();
        newHashtable.Add("name", Name);
        newHashtable.Add("parent", Parent);
        newHashtable.Add("dependsOn", DependsOn);
        
        string existing = IsExisting ? "existing " : "";
        return $"resource {Identifier} {ResourceType} {existing}= {PSBicepUtils.Convert(newHashtable)}";
    }

}
