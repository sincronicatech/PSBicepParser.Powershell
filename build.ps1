$module = 'PSBicepParser.Powershell'
Push-Location $PSScriptRoot

.\src\BicepGrammar\GenerateParser.ps1

dotnet publish "$PSScriptRoot/src/$module" -o "$PSScriptRoot/output/$module/bin"
Copy-Item "$PSScriptRoot\$module\*" "$PSScriptRoot\output\$module" -Recurse -Force

#Import-Module "$PSScriptRoot\output\$module\$module.psd1"
#Invoke-Pester "$PSScriptRoot\tests"
Pop-Location