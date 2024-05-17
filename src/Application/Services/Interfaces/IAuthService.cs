using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.ResponseStatus;

namespace Application.Services.Interfaces;

/// <summary>
/// Interface for a service that handles operations related to authentication.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Retrieves all user details.
    /// </summary>
    /// <param name="loginRequest">DTO contain information login</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A LoginResponse is cover by ResponseEntity</returns>
    Task<ResponseEntity<LoginResponse>> LoginAsync(
        LoginRequest loginRequest,
        CancellationToken cancellationToken
    );
}
