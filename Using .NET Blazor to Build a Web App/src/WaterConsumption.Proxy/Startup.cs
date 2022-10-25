using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Configurations.AppSettings.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WaterConsumption.Proxy.Configurations;

[assembly: FunctionsStartup(typeof(WaterConsumption.Proxy.Startup))]
namespace WaterConsumption.Proxy
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
            ConfigureAppSettings(builder.Services);
            ConfigureHttpClient(builder.Services);
        }

        private static void ConfigureAppSettings(IServiceCollection services)
        {
            var settings = services.BuildServiceProvider()
                                   .GetService<IConfiguration>()
                                   .Get<ProxySettings>(ProxySettings.Name);
            services.AddSingleton(settings);

            var codespaces = bool.TryParse(Environment.GetEnvironmentVariable("OpenApi__RunOnCodespaces"), out var isCodespaces) && isCodespaces;
            if (codespaces)
            {
                /* ⬇️⬇️⬇️ Add this ⬇️⬇️⬇️ */
                services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
                        {
                            var options = new DefaultOpenApiConfigurationOptions()
                            {
                                IncludeRequestingHostName = false
                            };

                            return options;
                        });
                /* ⬆️⬆️⬆️ Add this ⬆️⬆️⬆️ */
            }
        }

        private static void ConfigureHttpClient(IServiceCollection services)
        {
            services.AddHttpClient("proxy");
        }
    }
}