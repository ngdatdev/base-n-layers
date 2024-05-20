using System.Reflection;
using DataAccess.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Database;

namespace DataAccess.ServiceConfigs;

/// <summary>
///    SqlServer DbContext Pool service config.
/// </summary>
internal static class SqlServerDbContextPoolServiceConfig
{
    internal static void ConfigSqlServerContextPool(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services.AddDbContextPool<DatabaseContext>(
            optionsAction: (provider, config) =>
            {
                var baseDatabaseOption = configuration
                    .GetRequiredSection(key: "Database")
                    .GetRequiredSection(key: "Base")
                    .Get<DatabaseOption>();

                config
                    .UseSqlServer(
                        connectionString: baseDatabaseOption.ConnectionString,
                        sqlServerOptionsAction: databaseOptionsAction =>
                        {
                            databaseOptionsAction
                                .CommandTimeout(commandTimeout: baseDatabaseOption.CommandTimeOut)
                                .EnableRetryOnFailure(
                                    maxRetryCount: baseDatabaseOption.EnableRetryOnFailure
                                )
                                .MigrationsAssembly(
                                    assemblyName: Assembly.GetExecutingAssembly().GetName().Name
                                );
                        }
                    )
                    .EnableSensitiveDataLogging(
                        sensitiveDataLoggingEnabled: baseDatabaseOption.EnableSensitiveDataLogging
                    )
                    .EnableDetailedErrors(
                        detailedErrorsEnabled: baseDatabaseOption.EnableDetailedErrors
                    )
                    .EnableThreadSafetyChecks(
                        enableChecks: baseDatabaseOption.EnableThreadSafetyChecks
                    )
                    .EnableServiceProviderCaching(
                        cacheServiceProvider: baseDatabaseOption.EnableServiceProviderCaching
                    );
            }
        );
    }
}
