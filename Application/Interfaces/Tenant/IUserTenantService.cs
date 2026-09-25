namespace Application.Interfaces.Tenant;

public interface IUserTenantService
{
    Task<Result<string>> AddUserToTenantAsync(AddUserToTenantDto dto, CancellationToken ct);
}
