using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Antlr4.Runtime;

namespace BicepParser.Powershell;

internal class PSBicepUtils
{
    internal static PSBicepDocument Parse(string inputObject)
    {
        AntlrInputStream inputStream = new AntlrInputStream(inputObject);

        
        var lexer = new bicepLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);

        var parser = new bicepParser(commonTokenStream);

        var startContext = parser.bicep();

        var documentVisitor = new BicepDocumentVisitor();
        var document = documentVisitor.VisitBicep(startContext);

        return document;
    }

    internal static string Convert(Hashtable hashtable){
        var sb = new StringBuilder();
        sb.AppendLine("{");
        Regex lineAdder = new Regex("\n");
        foreach(var key in hashtable.Keys){
            string valueToAdd;
            switch(hashtable[key])
            {
                case Hashtable hs:
                    if(hs.Count == 0) continue;
                    valueToAdd = lineAdder.Replace(Convert(hs),"\n  ");
                    break;
                case object[] ar:
                    if(ar.Length == 0) continue;
                    valueToAdd = lineAdder.Replace(Convert(ar),"\n  ");
                    break;
                default:
                    if(hashtable[key]==null) continue;
                    valueToAdd = hashtable[key].ToString();
                    break;
            }
            sb.AppendLine($"  {key}: {valueToAdd}");
        }
        sb.Append("}");

        return sb.ToString();
    }

    internal static string Convert(object[] array){
        var sb = new StringBuilder();
        sb.AppendLine("[");
        Regex lineAdder = new Regex("\n");
        foreach(var element in array){
            string valueToAdd;
            switch(element)
            {
                case Hashtable hs:
                    valueToAdd = lineAdder.Replace(Convert(hs),"\n  ");
                    break;
                case object[] ar:
                    valueToAdd = lineAdder.Replace(Convert(ar),"\n  ");
                    break;
                default:
                    valueToAdd = element.ToString();
                    break;
            }
            sb.AppendLine($"  {valueToAdd}");
        }
        sb.Append("]");

        return sb.ToString();
    }

    internal static string Convert(object value)
    {
        switch(value)
        {
            case Hashtable hs:
                return Convert(hs);
            case object[] ar:
                return Convert(ar);
            default:
                return value.ToString();
        }
    }
}
