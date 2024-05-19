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
internal sealed class GlobalExceptionHandlerCustom
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly RequestDelegate  _next;

    public GlobalExceptionHandlerCustom(
        RequestDelegate next,
        IServiceScopeFactory serviceScopeFactory
    )
    {
        _serviceScopeFactory = serviceScopeFactory;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            httpContext.Response.Clear(); // give a delete try
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(
                value: new ErrorHttpResponse
                {
                    HttpCode = StatusCodes.Status500InternalServerError,
                    ErrorMessages =
                    [
                        "Server has encountered an error !"
                    ]
                }
            );

            await httpContext.Response.CompleteAsync();
        }
    }
}
