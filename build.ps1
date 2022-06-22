param(
    $version=$null
)
$module = 'PSBicepParser'
Push-Location $PSScriptRoot

.\src\BicepGrammar\GenerateParser.ps1

dotnet publish "$PSScriptRoot/src/$module" -o "$PSScriptRoot/output/$module/bin"
Copy-Item "$PSScriptRoot\manifests\$module\*" "$PSScriptRoot\output\$module" -Recurse -Force
if($null -ne $version)
{
    Update-ModuleManifest -Path "$PSScriptRoot\output\$module\$module.psd1" -ModuleVersion $version
}
#Import-Module "$PSScriptRoot\output\$module\$module.psd1"
#Invoke-Pester "$PSScriptRoot\tests"
Pop-Location