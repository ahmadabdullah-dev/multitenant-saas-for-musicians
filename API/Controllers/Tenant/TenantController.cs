using Application.Dtos.Tenant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Tenant;

public class TenantController : BaseApiController
{
    private readonly ITenantService _tenantService;
    public TenantController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }
    [HttpPost("create-tenant")]
    [Authorize(Policy = "SuperAdminOnly")]
    public async Task<ActionResult> CreateTenant([FromBody] CreateTenantDto dto, CancellationToken ct)
    {
        var result = await _tenantService.CreateTenantAsync(dto, ct);
        return HandleResult(result);
    }
    [HttpGet("{tenantId}")]
    public async Task<ActionResult> CreateTenant(string tenantId, CancellationToken ct)
    {
        var result = await _tenantService.GetTenantByIdAsync(tenantId, ct);
        return HandleResult(result);
    }
}
