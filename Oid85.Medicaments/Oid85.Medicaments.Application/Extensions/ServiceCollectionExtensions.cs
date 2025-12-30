using Microsoft.Extensions.DependencyInjection;
using Oid85.Medicaments.Application.Interfaces.Services;
using Oid85.Medicaments.Application.Services;

namespace Oid85.Medicaments.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationServices(
        this IServiceCollection services)
    {
        services.AddTransient<IPillService, PillService>();
    }
}