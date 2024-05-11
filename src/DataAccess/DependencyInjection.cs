using DataAccess.ServiceConfigs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

/// <summary>
///     Entry to configuring multiple services
///     of sql server relational database.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Entry to configuring multiple services.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Load configuration for configuration
    ///     file (appsetting).
    /// </param>
    public static void ConfigSqlServerRelationalDatabase(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.ConfigSqlServerContextPool(configuration: configuration);
        services.ConfigCore();
        services.ConfigAspNetCoreIdentity(configuration: configuration);
    }
}
