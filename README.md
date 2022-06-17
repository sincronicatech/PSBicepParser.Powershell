# Bicep Converter for Powershell
Bicep Converter for Powershell.

The module aims to parse a Bicep file to a Powershell object and viceversa to simplify the manipulation of Bicep files on CI/CD pipelines.

The module exposes the following cmdLets:

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
- While the Antlr grammar is able to decode interpolated strings, the module treats them as strings
- While the Antlr grammar is able to parse variables, the module treats them as strings right now. 
  - If you want to assign a variable to an attribute, just write the name of the variable
  - If you want to assign a string to an attribute, write the string with starting and closing apex

## Example

``` powershell
Import-module .\src\PSBicepParser.Powershell\bin\Debug\netstandard2.0\publish\PSBicepParser.Powershell.dll 
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

### Grammar

Java 11 is required to build the grammar. Launch the GenerateParser.ps1 script in the BicepGrammar directory to generate the c# parser and lexer.

### CmdLets

Just launch 

```
dotnet publish
```

to build the module