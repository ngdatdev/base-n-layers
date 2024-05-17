using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Concrete;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;

namespace ServiceConfigs;

/// <summary>
///     Core service config.
/// </summary>
internal static class CoreServiceConfig
{
    internal static void ConfigCore(this IServiceCollection services)
    {
        services.AddScoped<IUserDetailService, UserDetailService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddSingleton<JsonWebTokenHandler>();
    }
}
