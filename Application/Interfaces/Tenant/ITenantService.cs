namespace Application.Interfaces.Tenant;

public interface ITenantService
{
    Task<Result<string>> CreateTenantAsync(CreateTenantDto dto, CancellationToken ct);

}
