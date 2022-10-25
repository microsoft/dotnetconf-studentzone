using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using WaterConsumption.Web;
using WaterConsumption.Web.Proxies;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp =>
{
    var http = sp.GetService<HttpClient>();
    var proxy = new ProxyClient(http);
    if (builder.HostEnvironment.IsDevelopment() != true)
    {
        proxy.BaseUrl = $"{builder.HostEnvironment.BaseAddress.TrimEnd('/')}/api";
    }

    var codespaces = builder.Configuration.GetValue<bool>("RunOnCodespaces");
    if (codespaces)
    {
        proxy.BaseUrl = $"{builder.HostEnvironment.BaseAddress.TrimEnd('/')}/api";
    }

    return proxy;
});

await builder.Build().RunAsync();
