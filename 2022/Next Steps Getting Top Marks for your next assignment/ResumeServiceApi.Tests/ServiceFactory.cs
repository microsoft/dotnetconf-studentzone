using API.Models;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ResumeServiceApi.Tests;

internal class ServiceFactory
{
    public static WebApplicationFactory<Program> CreateTestServerFactoryAsync()
    {
        var builder = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.ReplaceWithInMemoryDbContext<ResumeDb>();
            });
        });
        ;
        builder.CreateClient().GetAsync("/");
        return builder;
    }
}