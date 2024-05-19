using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Response;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Attribute.JwtAttribute;

namespace WebAPI.Controllers;

[ApiController]
public class UserDetailController : ControllerBase
{
    private readonly IUserDetailService _userDetailService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserDetailController(
        IUserDetailService userDetailService,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _userDetailService = userDetailService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("/haha")]
    public async Task<ActionResult<UserDetailResponse>> Get(CancellationToken cancellationToken)
    {
        var userDetail = await _userDetailService.GetAllUserDetails(
            cancellationToken: cancellationToken
        );
        return Ok(userDetail);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [RequireJwt]
    [HttpGet("hehe")]
    public async Task<ActionResult<UserDetailResponse>> GetA(CancellationToken cancellationToken)
    {
        var userDetail = await _userDetailService.GetAllUserDetails(
            cancellationToken: cancellationToken
        );
        return Ok(userDetail);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("/kaka")]
    public ActionResult<List<string>> GetB()
    {
        var claims = _httpContextAccessor.HttpContext.User.Claims;
        List<string> strings = new List<string>();
        foreach (var claim in claims)
        {
            strings.Add($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
        }
        return strings;
    }
}
