using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.ServiceConfigs;

namespace WebAPI
{
    internal static class DependencyInjection
    {
        internal static void ConfigWebAPIService(
            this IServiceCollection services,
            IConfigurationManager configuration
        )
        {
            services.ConfigAuthentication(configuration: configuration);
            services.ConfigAuthorization();
        }
    }
}
