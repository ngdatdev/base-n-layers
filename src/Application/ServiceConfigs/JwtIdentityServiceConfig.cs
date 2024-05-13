using Application.IdentityService.Jwt;
using Application.IdentityService.Jwt.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceConfigs;

/// <summary>
///     Jwt identity service config.
/// </summary>
internal static class JwtIdentityServiceConfig
{
    internal static void ConfigJwtIdentity(this IServiceCollection services)
    {
        services
            .AddSingleton<IAccessTokenHandler, AccessTokenHandler>()
            .AddSingleton<IRefreshTokenHandler, RefreshTokenHandler>();
    }
}
