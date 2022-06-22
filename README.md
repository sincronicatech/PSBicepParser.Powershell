# PSBicepParser module to parse Azure Bicep files
Powershell parser for Azure Bicep files. It makes easier parsing Bicep files. To be used in CI/CD pipeline that needs to manipulate an Azure Bicep file before deploying.

Cmdlets in the module:

- ### New-PSBicepDocument

Creates a new BicepDocument Powershell object

- ### New-PSBicepModule

Creates a new BicepModule Powershell object that can be assigned to a BicepDocument

- ### New-PSBicepOutput

Creates a new BicepOutput Powershell object that can be assigned to a BicepDocument

- ### New-PSBicepParam

Creates a new BicepParam Powershell object that can be assigned to a BicepDocument

- ### New-PSBicepResource

Creates a new BicepResource Powershell object that can be assigned to a BicepDocument

- ### New-PSBicepTargetScope

Creates a new BicepTargetScope Powershell object that can be assigned to a BicepDocument

- ### ConvertFrom-PSBicepDocument

Converts a string to a BicepDocument Powershell object.

- ### ConvertTo-PSBicepDocument

Converts a BicepDocument Powershell object to a string that represents the content of a Bicep file.

- ### Get-PSBicepReference

Analyzes the Bicep Object or the Bicep string and returns a list of references used by it

- ### Resolve-PSBicepReference

Given an identifier and a parsed Bicep document, returns the element referred by the identifier.

## Notes

- Currently "for" blocks are not recognized by the grammar
- The parser does not distinguish between variables, identifiers and interpolated strings. However the Get-PSBicepReference cmdLet is able to identify references even inside an interpolated string

## Example

``` powershell
Import-module .\src\PSBicepParser\bin\Debug\netstandard2.0\publish\PSBicepParser.dll 
# reading the api management bicep quickstart
$url = 'https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.apimanagement/azure-api-management-create/main.bicep'
$request = Invoke-WebRequest -Uri $url
$content = $request.content

# Convert to a Bicep Powershell object
$bicepDocument = $content|convertfrom-PSBicepDocument

$bicepDocument

# Add a new Bicep Param
$paramnew = new-PSBicepParam -Identifier 'theParam' -Type 'string'
$bicepDocument.Params+=$paramnew

# Print a list of references found in the document resource
$bicepDocument.Resources|Get-PSBicepReference

Resolve-PSBicepReference -Identifier 'sku' -DocumentObject $bicepDocument

# Convert to Bicep Document
$bicepDocument|convertto-PSBicepDocument
```

## Build

Java 11 is required to generate the c# parser. Execute the GenerateParser.ps1 script in the BicepGrammar directory to generate the c# parser and lexer. Generated parser and lexer are gitignored.

To build the module, just launch the build.ps1 script: it will both build the parser and the module.
