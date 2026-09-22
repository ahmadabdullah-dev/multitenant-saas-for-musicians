using Domain.Common.Identity;

namespace Domain.Tenant.Identity;

public class TenantUser : AppUser
{
    public required string TenantId { get; set; }
}