Import-module $PSScriptRoot\..\output\PSBicepParser\

Describe 'Convert-PSBicepDocument' {
    It 'Returns an Bicep Document with from a standard Bicep file' {

        # reading the api management bicep quickstart
        $url = 'https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.apimanagement/azure-api-management-create/main.bicep'
        $request = Invoke-WebRequest -Uri $url
        $content = $request.content

        # Convert to a bicep powershell object
        $bicepDocument = $content|convertfrom-PSBicepDocument
        $bicepDocument.Params.Count | Should -Be 6
        $bicepDocument.AllObjects.Count | Should -Be 7
    }
}
