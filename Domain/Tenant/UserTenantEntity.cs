namespace Domain.Tenant;

public class UserTenantEntity : BaseEntity
{
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;

    public string TenantId { get; set; } = null!;
    public TenantEntity Tenant { get; set; } = null!;

    public string Role { get; set; } = "Member";
}
