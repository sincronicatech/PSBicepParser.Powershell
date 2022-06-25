param(
    $version=$null
)
$module = 'PSBicepParser'
Push-Location $PSScriptRoot

if(Test-Path './output'){
    Remove-Item './output' -Force -Recurse
}
mkdir "$PSScriptRoot/output/$module"

.\src\BicepGrammar\GenerateParser.ps1

dotnet clean "$PSScriptRoot/src/$module"
dotnet publish "$PSScriptRoot/src/$module" -o "$PSScriptRoot/output/$module/bin"
Copy-Item "$PSScriptRoot\manifests\$module\*" "$PSScriptRoot\output\$module" -Recurse -Force
if($null -ne $version)
{
    Update-ModuleManifest -Path "$PSScriptRoot\output\$module\$module.psd1" -ModuleVersion $version
}
Compress-Archive "./output/$module/" "./output/$module.zip"
Pop-Location