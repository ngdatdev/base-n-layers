using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ResponseStatus;
using Microsoft.AspNetCore.Http;
using WebAPI.ApiResponse;

namespace WebAPI.HttpResponseMapper;

/// <summary>
///     Manages the mapping between app
///     response and http response for error api.
/// </summary>
internal sealed class ErrorHttpResponseManager
{
    private readonly Dictionary<ResponseStatusCode, Func<ErrorHttpResponse>> _dictionary;

    internal ErrorHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: ResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: () =>
                new()
                {
                    HttpCode = StatusCodes.Status400BadRequest,
                    ErrorMessages = ["Inputs is not valid"]
                }
        );
    }

    internal Func<ErrorHttpResponse> Resolve(ResponseStatusCode statusCode)
    {
        return _dictionary[statusCode];
    }
}
