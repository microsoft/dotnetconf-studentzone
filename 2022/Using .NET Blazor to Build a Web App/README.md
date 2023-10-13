# Blazor WebAssembly App for Water Consumption Tracker #

This is a Blazor WebAssembly (WASM) app tracking water consumptions.


## Prerequisites ##

* [.NET SDK 6.0.402+](https://dotnet.microsoft.com/en-us/download/dotnet/6.0?WT.mc_id=academic-78652-leestott)
* [PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell?WT.mc_id=academic-78652-leestott)
* [Bicep CLI](https://learn.microsoft.com/azure/azure-resource-manager/bicep/install?WT.mc_id=academic-78652-leestott)
* [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli?WT.mc_id=academic-78652-leestott)
* [GitHub CLI](https://cli.github.com/manual/installation?WT.mc_id=academic-78652-leestott)
* [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd?WT.mc_id=academic-78652-leestott)
* [Azure Functions Core Tools](https://learn.microsoft.com/azure/azure-functions/functions-run-local?WT.mc_id=academic-78652-leestott)
* [Static Web App CLI](https://azure.github.io/static-web-apps-cli/docs/use/install?WT.mc_id=academic-78652-leestott)
* [NSwag CLI](https://www.npmjs.com/package/nswag)


## Getting Started ##

### Assumptions ###

This app assumes the followings:

* The app development is done within GitHub Codespaces.
* There is a backend API that the proxy API requests the water consumption data.


### App Settings ###

This app consists of Blazor WASM as a front-end app and Azure Functions as a proxy API (and another Azure Functions as a backend API). Therefore, before running this application, you need to copy three files:

* WebApp (Blazor WASM): `appsettings.sample.json` to `appsettings.json`
* ProxyApp (Azure Functions): `local.settings.json` to `local.settings.json`
* ApiApp (Azure Functions): `local.settings.json` to `local.settings.json`


### Local Machine ###

To run this app on your local machine, run the following commands:

```bash
# Run both WebApp and ProxyApp
swa start
```

```bash
# Run the ApiApp
cd src/ApiApp

# API app needs to take a different port number other than 7071
func start --port 7072
```

Then, open your web browser and type the URL `http://localhost:4280` into the location bar.


### GitHub Codespaces ###

To run this app on your GitHub Codespaces, you need to update your `appsettings.json` and `local.settings.json` files.

* Copy your `appsettings.json` to `appsettings.Development.json` and update the `RunOnCodespaces` value to `true`.

    ```jsonc
    // appsettings.Development.json
    {
      "RunOnCodespaces": true
    }
    ```

* Run the following command to update your `local.settings.json`:

    ```bash
    pwsh -c "Invoke-RestMethod https://aka.ms/azfunc-openapi/add-codespaces.ps1 | Invoke-Expression"
    ```

Then run the following commands:

```bash
# Run both WebApp and ProxyApp
swa start
```

```bash
# Run the ApiApp
cd src/ApiApp

# API app needs to take a different port number other than 7071
func start --port 7072
```

### OpenAPI Document Generation ###

In case you want to generate the OpenAPI document from the backend API, run either bash shell script or PowerShell script to get OpenAPI document for the proxy API:

```bash
# Bash Shell: Generate OpenAPI document
curl -fsSL https://aka.ms/azfunc-openapi/generate-openapi.sh \
    | bash -s -- \
        -p src/ApiApp \
        -e openapi/v3.json \
        -o ./ \
        -f openapi.json \
        -d 30
```

```powershell
# PowerShell: Generate OpenAPI document
& $([Scriptblock]::Create($(Invoke-RestMethod https://aka.ms/azfunc-openapi/generate-openapi.ps1))) `
    -FunctionAppPath src/ApiApp `
    -Endpoint openapi/v3.json `
    -OutputPath ./ `
    -OutputFilename openapi.json `
    -Delay 30
```


### OpenAPI Proxy Client ###

In case you want to re-generate the proxy client from the OpenAPI document, run the NSwag CLI command:

```bash
# For WebApp
nswag openapi2csclient \
    /Input:"./openapi.json" \
    /Output:"src/WebApp/ProxyClient.cs" \
    /Namespace:"WebApp.Proxies" \
    /ClassName:"ProxyClient" \
    /JsonLibrary:"SystemTextJson" \
    /ServiceSchemes:"http" \
    /ServiceHost:"localhost:7071" \
    /ParameterDateTimeFormat:"u"

# For ProxyApp
nswag openapi2csclient \
    /Input:"./openapi.json" \
    /Output:"src/ProxyApp/ProxyClient.cs" \
    /Namespace:"ProxyApp.Proxies" \
    /ClassName:"ProxyClient" \
    /JsonLibrary:"NewtonsoftJson" \
    /ServiceSchemes:"http" \
    /ServiceHost:"localhost:7071" \
    /ParameterDateTimeFormat:"u"
```
