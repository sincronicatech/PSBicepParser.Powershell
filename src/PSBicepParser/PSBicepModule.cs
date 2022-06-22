using System.Collections;

namespace BicepParser.Powershell;

public class PSBicepModule:IPSBicepObject
{
    public PSBicepModule(string identifier, string modulePath, string name)
    {
        Identifier = identifier;
        ModulePath = modulePath;
        Name = name;
    }

    public string Identifier { get; set; }
    public string ModulePath { get; set; }
    public string Name { get; private set;}
    
    public string ElementType => "Module";

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
        }
    }

    public string ConvertToDocument()
    {
        var newHashtable = (Hashtable)Attributes.Clone();
        newHashtable.Add("name", Name);
        
        return $"module {Identifier} {ModulePath} = {PSBicepUtils.Convert(newHashtable)}";
    }

    
}
