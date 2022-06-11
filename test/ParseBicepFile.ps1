Import-module ..\src\BicepParser.Powershell\bin\Debug\netstandard2.0\BicepParser.Powershell.dll

# reading the api management bicep quickstart
$url = 'https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.apimanagement/azure-api-management-create/main.bicep'
$request = Invoke-WebRequest -Uri $url
$content = $request.content

# Convert to a bicep powershell object
$bicepDocument = $content|convertfrom-bicepDocument

$bicepDocument

# Add a new bicep Param
$paramnew = new-BicepParam -Identifier 'theParam' -Type 'string'
$bicepDocument.Params+=$paramnew

# Convert to bicep string
$bicepDocument|convertto-BicepDocument