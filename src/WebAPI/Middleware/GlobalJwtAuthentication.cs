using System;
using System.Security.Claims;
using System.Threading;
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
            TokenValidationParameters tokenValidationParameters,
            IServiceScopeFactory serviceScopeFactory
        )
        {
            _next = next;
            _tokenValidationParameters = tokenValidationParameters;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context, CancellationToken ct)
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

            // Validate access token.
            var validateTokenResult = await jsonWebTokenHandler.ValidateTokenAsync(
                token: context
                    .Request.Headers.Authorization[0]
                    ?.ToString()
                    .Split(separator: " ")[1],
                validationParameters: _tokenValidationParameters
            );

            // Token is not valid.
            if (
                !validateTokenResult.IsValid
                || validateTokenResult.SecurityToken.ValidTo < DateTime.UtcNow
            )
            {
                await SendResponseAsync(
                    context: context,
                    statusCode: StatusCodes.Status403Forbidden,
                    cancellationToken: ct
                );
            }

            var jtiClaim = context.User.FindFirstValue(claimType: JwtRegisteredClaimNames.Jti);

            await using var scope = _serviceScopeFactory.CreateAsyncScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var isRefreshTokenFound =
                await unitOfWork.RefreshTokenRepository.IsRefreshTokenFoundByAccessTokenIdQueryAsync(
                    accessTokenId: Guid.Parse(jtiClaim),
                    cancellationToken: ct
                );

            // Refresh token is not found by access token id.
            if (!isRefreshTokenFound)
            {
                await SendResponseAsync(
                    statusCode: StatusCodes.Status403Forbidden,
                    context: context,
                    cancellationToken: ct
                );
            }

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            // Get the sub claim from the access token.
            var subClaim = context.User.FindFirstValue(claimType: JwtRegisteredClaimNames.Sub);

            // Find user by user id.
            var foundUser = await userManager.FindByIdAsync(
                userId: Guid.Parse(input: subClaim).ToString()
            );

            // User is not found
            if (Equals(objA: foundUser, objB: default))
            {
                await SendResponseAsync(
                    statusCode: StatusCodes.Status403Forbidden,
                    context: context,
                    cancellationToken: ct
                );
            }

            // Is user temporarily removed.
            var isUserTemporarilyRemoved =
                await unitOfWork.UserDetailRepository.IsUserTemporarilyRemovedAsync(
                    id: foundUser.Id,
                    cancellationToken: ct
                );

            // User is temporarily removed.
            if (isUserTemporarilyRemoved)
            {
                await SendResponseAsync(
                    statusCode: StatusCodes.Status403Forbidden,
                    context: context,
                    cancellationToken: ct
                );
            }

            // Get the role claim from the access token.
            var roleClaim = context.User.FindFirstValue(claimType: "role");

            // Is user in role.
            var isUserInRole = await userManager.IsInRoleAsync(user: foundUser, role: roleClaim);
            if (!isUserInRole)
            {
                await SendResponseAsync(
                    statusCode: StatusCodes.Status403Forbidden,
                    context: context,
                    cancellationToken: ct
                );
            }
        }

        private static Task SendResponseAsync(
            HttpContext context,
            int statusCode,
            CancellationToken cancellationToken
        )
        {
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync("Forbidden", cancellationToken: cancellationToken);
        }
    }
}
