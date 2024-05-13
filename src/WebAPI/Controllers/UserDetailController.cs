using System.Threading;
using System.Threading.Tasks;
using Application.DTOs.Response;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        var  userDetail = await _userDetailService.GetAllUserDetails(cancellationToken: cancellationToken);
        return Ok(userDetail);
    }
}
