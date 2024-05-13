using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Shared.Configuration.Authentication;

namespace Application.IdentityService.Jwt.Handler;

/// <summary>
///     Implementation of jwt generator interface.
/// </summary>

/// <summary>
///     Implementation of jwt generator interface.
/// </summary>
internal sealed class AccessTokenHandler : IAccessTokenHandler
{
    private readonly JsonWebTokenHandler _jsonWebTokenHandler;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly JwtAuthenticationOption _jwtAuthenticationOption;

    public AccessTokenHandler(
        JwtAuthenticationOption jwtAuthenticationOption,
        JsonWebTokenHandler jsonWebTokenHandler,
        TokenValidationParameters tokenValidationParameters
    )
    {
        _jwtAuthenticationOption = jwtAuthenticationOption;
        _jsonWebTokenHandler = jsonWebTokenHandler;
        _tokenValidationParameters = tokenValidationParameters;
    }

    public string GenerateSigningToken(IEnumerable<Claim> claims)
    {
        // Validate set of user claims.
        if (claims.Equals(obj: Enumerable.Empty<Claim>()) || Equals(objA: claims, objB: default))
        {
            return string.Empty;
        }

        SecurityTokenDescriptor tokenDescriptor =
            new()
            {
                Audience = _jwtAuthenticationOption.Jwt.ValidAudience,
                Issuer = _jwtAuthenticationOption.Jwt.ValidIssuer,
                Subject = new(claims),
                // TokenType = _jwtAuthenticationOption.Jwt.ValidTypes.FirstOrDefault(),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(value: 15),
                SigningCredentials = new(
                    key: _tokenValidationParameters.IssuerSigningKey, // give it a try
                    algorithm: SecurityAlgorithms.HmacSha256
                ),
            };

        return _jsonWebTokenHandler.CreateToken(tokenDescriptor);
    }
}
