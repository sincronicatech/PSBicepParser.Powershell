Import-module $PSScriptRoot\..\output\PSBicepParser\

Describe 'New-PSBicepDocument' {
    It 'Returns an Bicep Document' {
        $document = New-PSBicepDocument
        $document.AllObjects.Count | Should -Be 0
    }
}

Describe 'New-PSBicepDocument' {
    It 'Returns an Bicep Document with a custom targetScope' {
        $document = New-PSBicepDocument
        $document.targetScope = New-PSBicepTargetScope -Scope '''subscription'''
        $document.AllObjects.Count | Should -Be 0
        $document.TargetScope.Scope | Should -Be '''subscription'''
    }
}


