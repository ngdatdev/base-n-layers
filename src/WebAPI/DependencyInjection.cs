using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.ServiceConfigs;

namespace WebAPI;

/// <summary>
///     Entry to configuring multiple services
///     of sql server relational database.
/// </summary>
internal static class DependencyInjection
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
    internal static void ConfigWebAPIService(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.ConfigAuthentication(configuration: configuration);
        services.ConfigAuthorization();
    }
}
