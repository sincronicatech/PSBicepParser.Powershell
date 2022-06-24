Import-module $PSScriptRoot\..\output\PSBicepParser\

Describe 'New-PSBicepDocument' {
    It 'Returns an Bicep Document with a custom targetScope' {
        $TargetScope = New-PSBicepTargetScope -Scope '''subscription'''
        $TargetScope.Scope | Should -Be '''subscription'''
    }
}