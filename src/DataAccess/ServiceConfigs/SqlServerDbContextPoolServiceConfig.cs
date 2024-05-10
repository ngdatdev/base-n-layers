using DataAccess.Data.DataContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Shared.Database;

namespace DataAccess.ServiceConfigs;

internal static class SqlServerDbContextPoolServiceConfig
{
    internal static void ConfigSqlServerContextPool(
        this IServiceCollection services,
        IConfigurationManager configuration
    ) { 
        services.AddDbContextPool<DatabaseContext>(optionsAction: (provider, config) =>
        {
            var baseDatabaseOption = configuration
                .GetRequiredSection(key: "Database")
                .GetRequiredSection(key: "Base")
                .Get<DatabaseOption>();

            config.UseSqlServer(
                    connectionString: baseDatabaseOption.ConnectionString,
                    sqlServerOptionsAction: databaseOptionsAction =>
                    {
                        databaseOptionsAction
                            .CommandTimeout(commandTimeout: baseDatabaseOption.CommandTimeOut)
                            .EnableRetryOnFailure(maxRetryCount: baseDatabaseOption.EnableRetryOnFailure)
                            .MigrationsAssembly(assemblyName: Assembly.GetExecutingAssembly().GetName().Name);
                    })
                .EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: baseDatabaseOption.EnableSensitiveDataLogging)
                .EnableDetailedErrors(detailedErrorsEnabled: baseDatabaseOption.EnableDetailedErrors)
                .EnableThreadSafetyChecks(enableChecks: baseDatabaseOption.EnableThreadSafetyChecks)
                .EnableServiceProviderCaching(cacheServiceProvider: baseDatabaseOption.EnableServiceProviderCaching);
        });
    }
}
