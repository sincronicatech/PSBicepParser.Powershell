using System.Collections;

namespace BicepParser.Powershell;

public class PSBicepModule:PSBicepElementBase
{
    public PSBicepModule(string identifier, string modulePath, string name)
    {
        Identifier = identifier;
        ModulePath = modulePath;
        Name = name;
    }

    public string Identifier { get; }
    public string ModulePath { get; }
    public string Name { get; private set;}
    
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

    public override string ConvertToDocument()
    {
        var newHashtable = (Hashtable)Attributes.Clone();
        newHashtable.Add("name", Name);
        
        return $"module {Identifier} {ModulePath} = {PSBicepUtils.Convert(newHashtable)}";
    }

    
}
