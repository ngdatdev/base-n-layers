using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Attribute.JwtAttribute;

namespace WebAPI.Middleware
{
    public class GlobalJwtAuthentication
    {
        private readonly RequestDelegate _next;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GlobalJwtAuthentication(
            RequestDelegate next,
            IOptions<TokenValidationParameters> tokenValidationParameters,
            IServiceScopeFactory serviceScopeFactory
        ) { }

        public async Task InvokeAsync(HttpContext context)
        {
            var enpoint = context.GetEndpoint();
            var requireJwtAttribute = enpoint.Metadata.GetMetadata<RequireJwtAttribute>();
            if (Equals(objA: requireJwtAttribute, objB: default))
            {
                await _next(context);
                return;
            }

            // if (!context.Request.Headers.ContainsKey("Authorization"))
            // {
            //     await SendResponseAsync(
            //         context: context,
            //         statusCode: StatusCodes.Status403Forbidden
            //     );
            //     return;
            // }

            JsonWebTokenHandler jsonWebTokenHandler = new();

            var validateTokenResult = await jsonWebTokenHandler.ValidateTokenAsync(
                token: context.Request.Headers.Authorization[0]?.ToString().Split(separator: " ")[1],
                validationParameters: _tokenValidationParameters
            );

            if(!validateTokenResult.IsValid) {
                await SendResponseAsync(
                    context: context, 
                    statusCode: StatusCodes.Status403Forbidden,
                );
            }

            var jtiClaim = context.User.FindFirstValue(claimType: JwtRegisteredClaimNames.Jti);

            await using var scope = _serviceScopeFactory.CreateAsyncScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var isRefreshTokenFound = await unitOfWork.

        }

        private static Task SendResponseAsync(HttpContext context, int statusCode)
        {
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync("Forbidden");
        }
    }
}
