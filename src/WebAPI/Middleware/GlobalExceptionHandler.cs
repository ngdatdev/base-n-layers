using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.ApiResponse;

namespace WebAPI.Middleware;

/// <summary>
///     Global Exception Handler
/// </summary>
internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public GlobalExceptionHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        httpContext.Response.Clear(); // give a delete try
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(
            value: new ErrorHttpResponse
            {
                HttpCode = StatusCodes.Status500InternalServerError,
                ErrorMessages =
                [
                    "Server has encountered an error !!",
                ]
            },
            cancellationToken: cancellationToken
        );

        await httpContext.Response.CompleteAsync();

        return true;
    }
}
