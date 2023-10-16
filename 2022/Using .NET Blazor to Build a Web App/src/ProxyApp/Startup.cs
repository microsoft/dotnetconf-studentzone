using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ProxyApp.Proxies;

[assembly: FunctionsStartup(typeof(ProxyApp.Startup))]
namespace ProxyApp
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            builder.ConfigurationBuilder
                   .AddEnvironmentVariables();

            base.ConfigureAppConfiguration(builder);
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            var http = new HttpClient();

            var config = services.BuildServiceProvider()
                                 .GetService<IConfiguration>();
            var apiHost = config.GetValue<string>("ApiHost");
            var apiKey = config.GetValue<string>("ApiKey");
            http.DefaultRequestHeaders.Add("x-functions-key", apiKey);

            var proxy = new ProxyClient(http);
            proxy.BaseUrl = $"{apiHost.TrimEnd('/')}/api";

            services.AddSingleton<ProxyClient>(proxy);
        }
    }
}