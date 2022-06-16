using System.Linq;
using Antlr4.Runtime;

namespace BicepParser.Powershell
{
    public abstract class PSBicepElementBase : IPSBicepElement
    {
        public abstract string ConvertToDocument();

        public string[] ReferredIdentifiers{
            get{
                AntlrInputStream inputStream = new AntlrInputStream(this.ConvertToDocument());

                var lexer = new bicepLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);

                var parser = new bicepParser(commonTokenStream);

                var startContext = parser.bicep();

                var identifierVisitor = new BicepReferenceVisitor();
                identifierVisitor.Visit(startContext);

                return identifierVisitor.references.ToArray<string>();

            }

        }
        
    }
}