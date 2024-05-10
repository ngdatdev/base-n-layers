using DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        internal static void ConfigWebApi(
            this IServiceCollection services,
            IConfigurationManager configuration
        )
        {
            services.ConfigSqlServerRelationalDatabase(configuration: configuration);
        }
    }
}
