Import-module $PSScriptRoot\..\output\PSBicepParser\

Describe 'Convert-ToBicepDocument' {
    It 'Returns an Bicep Document with from a standard Bicep file' {

        # reading the api management bicep quickstart
        $document = New-PSBicepDocument
        $document.targetScope = New-PSBicepTargetScope -Scope '''subscription'''
        $document.Params+=New-PSBicepParam -Identifier 'FirstParam' -Type 'string' -DefaultValue '''temp'''
        $document.Resources+=New-PSBicepResource -Identifier 'Resource' -Name 'Resource1' -ResourceType
        $document.AllObjects.Count | Should -Be 0
        $document.TargetScope.Scope | Should -Be '''subscription'''
    }
}