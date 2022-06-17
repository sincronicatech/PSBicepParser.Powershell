$module = 'PSBicepParser.Powershell'
Push-Location $PSScriptRoot

.\src\BicepGrammar\GenerateParser.ps1

dotnet build "$PSScriptRoot/src/$module" -o "$PSScriptRoot/output/$module/bin"
Copy-Item "$PSScriptRoot\$module\*" "$PSScriptRoot\output\$module" -Recurse -Force

Import-Module "$PSScriptRoot\Output\$module\$module.psd1"
Invoke-Pester "$PSScriptRoot\Tests"
Pop-Location