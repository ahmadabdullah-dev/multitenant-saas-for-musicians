using Microsoft.Extensions.Logging;

namespace Application.Services.Tenant;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly ILogger<TenantService> _logger;
    public TenantService(ITenantRepository tenantRepository, ILogger<TenantService> logger)
    {
        _tenantRepository = tenantRepository;
        _logger = logger;
    }
    public async Task<Result<string>> CreateTenantAsync(CreateTenantDto dto, CancellationToken ct)
    {
        var entity = new TenantEntity
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        try
        {
            await _tenantRepository.AddAsync(entity,ct);
            await _tenantRepository.SaveChangesAsync(ct);
            
        }
        catch(Exception ex)
        {
            _logger.LogError("Unexpected error happened while creatng tenant: " + ex.Message);
            return Result<string>.Failure("Unexpected error happened while creatng tenant",400);
        }

        return Result<string>.Success($"{dto.Name} tenant added successfully");

    }
}
