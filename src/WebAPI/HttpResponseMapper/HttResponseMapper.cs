using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ResponseStatus;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ApiResponse;

namespace WebAPI.HttpResponseMapper;

/// <summary>
///     extension methods to response api.
/// </summary>
internal static class HttResponseMapper
{
    private static ErrorHttpResponseManager _errorHttpResponseManager;

    internal static IActionResult ToApiResponse(dynamic responseDTO)
    {
        switch (responseDTO.StatusCode)
        {
            case ResponseStatusCode.OPERATION_SUCCESS:
                var successResponse = new SuccessHttpResponse { Body = responseDTO.Body };
                return new ObjectResult(successResponse) { StatusCode = successResponse.HttpCode, };

            default:
                _errorHttpResponseManager ??= new();
                var errorResponseFunc = _errorHttpResponseManager.Resolve(responseDTO.StatusCode);
                var errorResponse = errorResponseFunc();
                return new ObjectResult(errorResponse) { StatusCode = errorResponse.HttpCode };
        }
    }
}
