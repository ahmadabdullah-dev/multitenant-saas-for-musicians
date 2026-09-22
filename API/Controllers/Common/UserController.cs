using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

[Authorize]
public class UserController : BaseApiController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var result = await _userService.GetCurrentUserAsync();
        return HandleResult(result);
    }
}
