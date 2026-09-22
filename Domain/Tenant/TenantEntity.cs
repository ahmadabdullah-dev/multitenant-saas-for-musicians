namespace Domain.Tenant;

public class TenantEntity : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<UserTenantEntity> UserTenants { get; set;  } = new List<UserTenantEntity>();
}
