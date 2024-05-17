using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Request;
using Application.DTOs.Response;
using Application.IdentityService.Jwt;
using Application.ResponseStatus;
using Application.Services.Interfaces;
using Azure.Core;
using DataAccess.Entities;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Concrete;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IRefreshTokenHandler _refreshTokenHandler;
    private readonly IAccessTokenHandler _accessTokenHandler;

    public AuthService(
        IUnitOfWork unitOfWork,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IRefreshTokenHandler refreshTokenHandler,
        IAccessTokenHandler accessTokenHandler
    )
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _signInManager = signInManager;
        _refreshTokenHandler = refreshTokenHandler;
        _accessTokenHandler = accessTokenHandler;
    }

    public async Task<ResponseEntity<LoginResponse>> LoginAsync(
        LoginRequest loginRequest,
        CancellationToken cancellationToken
    )
    {
        var foundUser = await _userManager.FindByNameAsync(userName: loginRequest.Username);

        if (Equals(objA: foundUser, objB: default))
        {
            return new() { StatusCode = ResponseStatusCode.USERNAME_IS_NOT_FOUND, };
        }

        var doesUserHaveCurrentPassword = await _userManager.CheckPasswordAsync(
            user: foundUser,
            password: loginRequest.Password
        );

        // Password does not belong to user.
        if (!doesUserHaveCurrentPassword)
        { // Is user locked out.
            var userLockedOutResult = await _signInManager.CheckPasswordSignInAsync(
                user: foundUser,
                password: loginRequest.Password,
                lockoutOnFailure: true
            );

            // User is temporary locked out.
            if (userLockedOutResult.IsLockedOut)
            {
                return new() { StatusCode = ResponseStatusCode.USER_IS_LOCKED_OUT };
            }

            return new() { StatusCode = ResponseStatusCode.PASSWORD_IS_NOT_CORRECT };
        }

        // Is user not temporarily removed.
        var isUserTemporarilyRemoved =
            await _unitOfWork.UserDetailRepository.IsUserTemporarilyRemovedAsync(
                id: foundUser.Id,
                cancellationToken: cancellationToken
            );

        // User is temporarily removed.
        if (isUserTemporarilyRemoved)
        {
            return new() { StatusCode = ResponseStatusCode.USER_IS_TEMPORARILY_REMOVED };
        }

        // Get found user roles.
        var foundUserRoles = await _userManager.GetRolesAsync(user: foundUser);

        // Init list of user claims.
        List<Claim> userClaims =
        [
            new(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
            new(type: JwtRegisteredClaimNames.Sub, value: foundUser.Id.ToString()),
            new(type: "role", value: foundUserRoles[default])
        ];

        // Create new refresh token.
        RefreshToken newRefreshToken = new RefreshToken()
        {
            AccessTokenId = Guid.Parse(
                input: userClaims
                    .First(predicate: userClaim =>
                        userClaim.Type.Equals(JwtRegisteredClaimNames.Jti)
                    )
                    .Value
            ),
            UserId = foundUser.Id,
            ExpiredDate = loginRequest.IsRemember
                ? DateTime.UtcNow.AddDays(value: 7)
                : DateTime.UtcNow.AddDays(value: 3),
            CreatedAt = DateTime.UtcNow,
            RefreshTokenValue = _refreshTokenHandler.Generate(length: 15)
        };

        // Add new refresh token to the database.
        var dbResult = await _unitOfWork.RefreshTokenRepository.CreateRefreshTokenAsync(
            refreshToken: newRefreshToken,
            cancellationToken: cancellationToken
        );

        if (!dbResult)
        {
            return new() { StatusCode = ResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        // Generate access token.
        var newAccessToken = _accessTokenHandler.GenerateSigningToken(claims: userClaims);

        var userDetail = await _unitOfWork.UserDetailRepository.GetUserDetailByUserIdAsync(
            userId: foundUser.Id,
            cancellationToken: cancellationToken
        );

        return new()
        {
            StatusCode = ResponseStatusCode.OPERATION_SUCCESS,
            Body = new()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.RefreshTokenValue,
                User = new()
                {
                    FullName = $"{userDetail.FirstName} {userDetail.LastName}",
                    AvatarUrl = userDetail.AvatarUrl
                }
            }
        };
    }
}
