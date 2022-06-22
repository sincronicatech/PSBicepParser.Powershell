namespace BicepParser.Powershell
{
    public interface IPSBicepElement
    {
        string ConvertToDocument();
        string ElementType{ get; }
    }
}