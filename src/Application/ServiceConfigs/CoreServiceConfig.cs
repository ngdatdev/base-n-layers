using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Concrete;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceConfigs;

/// <summary>
///     Core service config.
/// </summary>
internal static class CoreServiceConfig
{
    internal static void ConfigCore(this IServiceCollection services)
    {
        services.AddScoped<IUserDetailService, UserDetailService>();
    }
}
