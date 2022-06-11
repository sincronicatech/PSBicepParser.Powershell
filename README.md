# Bicep Converter for Powershell
Bicep Converter for Powershell.

The module aims to parse a Bicep file to a Powershell object and viceversa to simplify the manipulation of Bicep files on CI/CD pipelines.

The module exposes the following cmdLets:

- ### New-BicepDocument

Creates a new BicepDocument Powershell object

- ### New-BicepModule

Creates a new BicepModule Powershell object that can be assigned to a BicepDocument

- ### New-BicepOutput

Creates a new BicepOutput Powershell object that can be assigned to a BicepDocument

- ### New-BicepParam

Creates a new BicepParam Powershell object that can be assigned to a BicepDocument

- ### New-BicepResource

Creates a new BicepResource Powershell object that can be assigned to a BicepDocument

- ### New-BicepTargetScope

Creates a new BicepTargetScope Powershell object that can be assigned to a BicepDocument

- ### ConvertFrom-BicepDocument

Convert a string to a BicepDocument Powershell object.

- ### ConvertTo-BicepDocument

Convert a BicepDocument Powershell object to a string that represents the content of a Bicep file.

## Notes

- Currently "for" blocks are not recognized by the grammar
- While the Antlr grammar is able to decode interpolated strings, the module treats them as strings
- While the Antlr grammar is able to parse variables, the module treats them as strings right now. 
  - If you want to assign a variable to an attribute, just write the name of the variable
  - If you want to assign a string to an attribute, write the string with starting and closing apex

## Examples

```
bello figo

