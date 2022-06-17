Write-host "Generating parser using Antlr"

Push-Location $PSScriptRoot
$antlJarName = 'antlr-4.10.1-complete.jar'
$antlrJarFile = "$env:TMP/$antlJarName"
if(-not (Test-Path $antlrJarFile))
{
    $antlrJarUri = "https://www.antlr.org/download/$antlJarName"
    $antlrJarResponse = Invoke-WebRequest -Uri $antlrJarUri
    [System.IO.File]::WriteAllBytes($antlrJarFile,$antlrJarResponse.Content)|out-null
}

if(Test-Path ./GeneratedCode)
{
    Remove-Item -Force ./GeneratedCode -Recurse -Confirm:$false
}
mkdir ./GeneratedCode|Out-Null

$bicepLexerGrammar = Get-Item "./bicepLexer.g4"
$bicepGrammar = Get-Item "./bicepParser.g4"

java --class-path $antlrJarFile org.antlr.v4.Tool -Dlanguage=CSharp $bicepLexerGrammar.FullName -o ./GeneratedCode -no-listener -no-visitor
java --class-path $antlrJarFile org.antlr.v4.Tool -Dlanguage=CSharp $bicepGrammar.FullName -o ./GeneratedCode -visitor 

if(Test-Path ../PSBicepParser.Powershell/parser)
{
    Remove-Item -Force ../PSBicepParser.Powershell/parser -Recurse -Confirm:$false
}
mkdir ../PSBicepParser.Powershell/parser |Out-Null
Move-Item ./GeneratedCode/*.cs ../PSBicepParser.Powershell/parser -Force

Pop-Location
