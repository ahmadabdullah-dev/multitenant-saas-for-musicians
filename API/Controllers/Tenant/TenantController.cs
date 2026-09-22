namespace API.Controllers.Tenant;

public class TenantController : BaseApiController
{
    private readonly ITenantService _tenantService;
    public TenantController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }
}
