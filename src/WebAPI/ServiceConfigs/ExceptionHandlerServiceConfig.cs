using Microsoft.Extensions.DependencyInjection;
using WebAPI.Middleware;

namespace WebAPI.ServiceConfigs
{
    internal static class ExceptionHandlerServiceConfig
    {
        internal static void ConfigureExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>().AddProblemDetails();
        }
    }
}
