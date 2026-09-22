using Application.Dtos.Common;
using Application.Interfaces.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common;

public class AuthController : BaseApiController
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);
        return HandleResult(result);
    }
}
