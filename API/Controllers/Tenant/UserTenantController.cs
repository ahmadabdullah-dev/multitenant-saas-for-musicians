namespace API.Controllers.Tenant;

public class UserTenantController : BaseApiController
{
    private readonly IUserTenantService _userTenantService;
    public UserTenantController(IUserTenantService userTenantService)
    {
        _userTenantService = userTenantService;
    }
}
