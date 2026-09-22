namespace Application.Interfaces.Tenant;

public interface ITenantAuthService
{
    Task<Result<string>> TenantLoginAsync(TenantLoginDto dto);
}
