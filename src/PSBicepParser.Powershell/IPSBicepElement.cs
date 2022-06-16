namespace BicepParser.Powershell;

internal interface IPSBicepElement
{
    string ConvertToDocument();
    public string[] ReferredIdentifiers {  get; }
}