using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Staff;

[Route("api/staff/auth")]
public class StaffAuthController : BaseApiController
{
    private readonly IStaffAuthService _staffAuthService;
    public StaffAuthController(IStaffAuthService staffAuthService)
    {
        _staffAuthService = staffAuthService;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] StaffLoginDto dto)
    {
        var result = await _staffAuthService.StaffLoginAsync(dto);
        return HandleResult(result);
    }
}
