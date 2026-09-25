using Application.Dtos.Tenant;
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
    public async Task<Result<TenantDto>> GetTenantByIdAsync(string tenantId, CancellationToken ct)
    {
        var entity = await _tenantRepository.GetByIdAsync(tenantId, ct);

        if (entity == null)
            return Result<TenantDto>.Failure("Tenant was not found", 404);

        var dto = new TenantDto
        {
            Id = tenantId,
            Name = entity.Name,
            Description = entity.Description
        };
        return Result<TenantDto>.Success(dto);
    }
    public async Task<bool> IsTenantExistsById(string id, CancellationToken ct)
    => await _tenantRepository.IsTenantExistsByIdAsync(id, ct);
        
    
}
