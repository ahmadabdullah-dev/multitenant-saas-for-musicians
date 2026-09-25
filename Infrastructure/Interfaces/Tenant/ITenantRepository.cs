namespace Infrastructure.Interfaces.Tenant;
public interface ITenantRepository : IRepository<TenantEntity>
{
     Task<bool> IsTenantExistsByIdAsync(string id, CancellationToken ct);
}
