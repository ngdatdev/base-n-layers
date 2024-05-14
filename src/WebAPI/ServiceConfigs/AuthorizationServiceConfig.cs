using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.ServiceConfigs;

/// <summary>
///     Authorization service config.
/// </summary>
public static class AuthorizationServiceConfig
{
    internal static void ConfigAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization();
    }
}