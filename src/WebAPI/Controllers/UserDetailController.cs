using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Response;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Attribute.JwtAttribute;

namespace WebAPI.Controllers;

[ApiController]
[Route("/userDetails")]
public class UserDetailController : ControllerBase
{
    private readonly IUserDetailService _userDetailService;

    public UserDetailController(IUserDetailService userDetailService)
    {
        _userDetailService = userDetailService;
    }

    [HttpGet]
    public async Task<ActionResult<UserDetailResponse>> Get(CancellationToken cancellationToken)
    {
        var userDetail = await _userDetailService.GetAllUserDetails(
            cancellationToken: cancellationToken
        );
        return Ok(userDetail);
    }

    [HttpGet("/hehe")]
    [Authorize]
    [RequireJwt]
    public async Task<ActionResult<UserDetailResponse>> GetA(CancellationToken cancellationToken)
    {
        var userDetail = await _userDetailService.GetAllUserDetails(
            cancellationToken: cancellationToken
        );
        return Ok(userDetail);
    }
}
