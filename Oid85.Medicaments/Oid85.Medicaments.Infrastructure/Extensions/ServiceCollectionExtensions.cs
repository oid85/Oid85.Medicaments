using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oid85.Medicaments.Application.Interfaces.Repositories;
using Oid85.Medicaments.Common.KnownConstants;
using Oid85.Medicaments.Infrastructure.Interceptors;
using Oid85.Medicaments.Infrastructure.Repositories;

namespace Oid85.Medicaments.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

        services.AddDbContextPool<MedicamentsContext>((serviceProvider, options) =>
        {
            var updateInterceptor = serviceProvider.GetRequiredService<UpdateAuditableEntitiesInterceptor>();

            options
                .UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresMedicamentsConnectionString)!)
                .AddInterceptors(updateInterceptor);
        });

        services.AddPooledDbContextFactory<MedicamentsContext>(options =>
            options
                .UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresMedicamentsConnectionString)!)
                .EnableServiceProviderCaching(false), poolSize: 32);

        services.AddTransient<IPillRepository, PillRepository>();
    }

    public static async Task ApplyMigrations(this IHost host)
    {
        var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
        await using var scope = scopeFactory.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<MedicamentsContext>();
        await context.Database.MigrateAsync();
    }
}