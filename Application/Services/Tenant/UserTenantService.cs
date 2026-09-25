using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.Services.Tenant;

public class UserTenantService : IUserTenantService
{
    private readonly IUserTenantRepository _userTenantRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly ILogger<UserTenantService> _logger;
    private readonly ITenantService _tenantService;
    
    public UserTenantService(
        IUserTenantRepository userTenantRepository,
        UserManager<AppUser> userManager,
        ILogger<UserTenantService> logger,
        ITenantService tenantService
        )
    {
        _userTenantRepository = userTenantRepository;
        _userManager = userManager;
        _logger = logger;
        _tenantService = tenantService;
    }
    public async Task<Result<string>> AddUserToTenantAsync(AddUserToTenantDto dto, CancellationToken ct)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId);
        
        if (user == null)
            return Result<string>.Failure("User was not found", 404);

        var tenant =  await _tenantService.IsTenantExistsById(dto.TenantId, ct);

        if (!tenant)
            return Result<string>.Failure("Tenant was not found", 404);

        var userTenant = new UserTenantEntity
        {
            TenantId = dto.TenantId,
            UserId = dto.UserId,
        };
        try
        {
            await _userTenantRepository.AddAsync(userTenant, ct);
            await _userTenantRepository.SaveChangesAsync(ct);
        }
        catch(Exception ex)
        {
            _logger.LogError("Unexpected error happened while adding the user to tenant: " + ex.Message);
            return Result<string>.Failure("Unexpected error happened while adding the user to tenant", 400);
        };

        return Result<string>.Success($"{user.UserName} Added to tenant successfully");
    }
}
