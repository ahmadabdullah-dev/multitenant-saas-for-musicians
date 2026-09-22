using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Tenant;

[Route("api/tenant/auth")]
public class TenantAuthController : BaseApiController
{
    private readonly ITenantAuthService _tenantAuthService;
    public TenantAuthController(ITenantAuthService tenantAuthService)
    {
        _tenantAuthService = tenantAuthService;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] TenantLoginDto dto)
    {
        var result = await _tenantAuthService.TenantLoginAsync(dto);
        return HandleResult(result);
    }
}
