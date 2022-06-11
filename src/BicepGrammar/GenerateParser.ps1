Write-host "Generating parser using Antlr. Java must be installed on the build machine"

$antlJarName = 'antlr-4.10.1-complete.jar'
$antlrJarFile = "$env:TMP/$antlJarName"
if(-not (Test-Path $antlrJarFile))
{
    $antlrJarUri = "https://www.antlr.org/download/$antlJarName"
    $antlrJarResponse = Invoke-WebRequest -Uri $antlrJarUri
    [System.IO.File]::WriteAllBytes($antlrJarFile,$antlrJarResponse.Content)|out-null
}

if(Test-Path .\GeneratedCode)
{
    Remove-Item -Force .\GeneratedCode 
}
mkdir .\GeneratedCode

$bicepLexerGrammar = Get-Item "./bicepLexer.g4"
$bicepGrammar = Get-Item "./bicepParser.g4"

java --class-path $antlrJarFile org.antlr.v4.Tool -Dlanguage=CSharp $bicepLexerGrammar.FullName -o ./GeneratedCode -no-listener -no-visitor
java --class-path $antlrJarFile org.antlr.v4.Tool -Dlanguage=CSharp $bicepGrammar.FullName -o ./GeneratedCode -visitor -no-listener

remove-item ../BicepParser.Powershell/parser/*
Move-Item ./GeneratedCode/*.cs ../BicepParser.Powershell/parser -Force
