namespace Application.Interfaces.Tenant;

public interface ITenantService
{
    Task<Result<string>> CreateTenantAsync(CreateTenantDto dto, CancellationToken ct);
    Task<Result<TenantDto>> GetTenantByIdAsync(string tenantId, CancellationToken ct);
    Task<bool> IsTenantExistsById(string id, CancellationToken ct);
}
