using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResumeServiceApi.Tests;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ReplaceWithInMemoryDbContext<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        if (services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TContext>)) is { } descriptor)

        {
            services.Remove(descriptor);
        }

        if (services.SingleOrDefault(d => d.ServiceType == typeof(TContext)) is { } descriptor2)
        {
            services.Remove(descriptor2);
        }

        services.AddDbContext<TContext>(options =>
        {
            options.UseInMemoryDatabase("test_db");
        });

        return services;
    }
}