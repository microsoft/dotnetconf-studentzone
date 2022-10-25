# Blazor WebAssembly App for Water Consumption Tracker #

This is a Blazor WebAssembly (WASM) app tracking water consumptions.


## Prerequisites ##

* [.NET SDK 6.0.402+](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Bicep CLI](https://learn.microsoft.com/azure/azure-resource-manager/bicep/install)
* [Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli)
* [GitHub CLI](https://cli.github.com/manual/installation)
* [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd)
* [Azure Functions Core Tools](https://learn.microsoft.com/azure/azure-functions/functions-run-local)
* [Static Web App CLI](https://azure.github.io/static-web-apps-cli/docs/use/install)
* [NSwag CLI](https://www.npmjs.com/package/nswag)


## Getting Started ##

### Assumptions ###

This app assumes the followings:

* The app development is done within GitHub Codespaces.
* There is a backend API that the proxy API requests the water consumption data.


### App Settings ###

This app consists of Blazor WASM as a front-end app and Azure Functions as a proxy API. Therefore, before running this application, you need to copy two files:

* Blazor WASM app: `appsettings.sample.json` to `appsettings.json`
* Azure Functions app: `local.settings.json` to `local.settings.json`


### Local Machine ###

To run this app on your local machine, run the following command:

```bash
swa start
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

Then run the following command:

```bash
swa start
```


### OpenAPI Document Generation ###

In case you want to re-generate the OpenAPI document from the proxy API, run either bash shell script or PowerShell script:
To get OpenAPI document for the proxy API:

```bash
# Bash Shell: Generate OpenAPI document
curl -fsSL https://aka.ms/azfunc-openapi/generate-openapi.sh \
    | bash -s -- \
        -p src/WaterConsumption.Proxy \
        -e openapi/v3.json \
        -o ./infra \
        -f openapi.json \
        -d 30
```

```powershell
# PowerShell: Generate OpenAPI document
& $([Scriptblock]::Create($(Invoke-RestMethod https://aka.ms/azfunc-openapi/generate-openapi.ps1))) `
    -FunctionAppPath src/WaterConsumption.Proxy `
    -Endpoint openapi/v3.json `
    -OutputPath ./infra `
    -OutputFilename openapi.json `
    -Delay 30
```


### OpenAPI Proxy Client ###

In case you want to re-generate the proxy client from the OpenAPI document, run the NSwag CLI command:

```bash
nswag openapi2csclient \
    /Input:"infra/openapi.json" \
    /Output:"src/WaterConsumption.Web/ProxyClient.cs" \
    /Namespace:"WaterConsumption.Web.Proxies" \
    /ClassName:"ProxyClient" \
    /JsonLibrary:"SystemTextJson" \
    /ServiceSchemes:"http" \
    /ServiceHost:"localhost:7071" \
    /ParameterDateTimeFormat:"u"
```
