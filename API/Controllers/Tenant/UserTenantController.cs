using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Tenant;

public class UserTenantController : BaseApiController
{
    private readonly IUserTenantService _userTenantService;
    public UserTenantController(IUserTenantService userTenantService)
    {
        _userTenantService = userTenantService;
    }
    [Authorize]
    [HttpPost("add-user-to-tenant")]
    public async Task<ActionResult> AddUserToTenant([FromBody] AddUserToTenantDto dto, CancellationToken ct)
    {
        var result = await _userTenantService.AddUserToTenantAsync(dto,ct);
        return HandleResult(result);
    }
}
