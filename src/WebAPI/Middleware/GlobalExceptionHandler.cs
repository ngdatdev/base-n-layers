using Microsoft.AspNetCore.Diagnostics;

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
            value: new CommonResponse
            {
                AppCode = (int)OtherAppCode.SERVER_ERROR,
                ErrorMessages =
                [
                    "Server has encountered an error !!",
                    "Please contact admin for support.",
                ]
            },
            cancellationToken: cancellationToken
        );

        await httpContext.Response.CompleteAsync();

        return true;
    }
}
