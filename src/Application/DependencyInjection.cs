using Application.Services.Concrete;
using Application.Services.Interfaces;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

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
    public static void ConfigApplication(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        // services.ConfigSqlServerRelationalDatabase(configuration: configuration);
        services.AddScoped<IUserDetailService, UserDetailService>();
    }
}
