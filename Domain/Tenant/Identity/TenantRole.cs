namespace Domain.Tenant.Identity;

public class TenantRole : AppRole
{
    public required string TenantId { get; set; }
}