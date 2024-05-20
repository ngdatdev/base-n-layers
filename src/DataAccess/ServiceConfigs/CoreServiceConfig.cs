using DataAccess.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ServiceConfigs;

/// <summary>
///     Core service config.
/// </summary>
internal static class CoreServiceConfig
{
    internal static void ConfigCore(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, SqlUnitOfWork>();
    }
}
