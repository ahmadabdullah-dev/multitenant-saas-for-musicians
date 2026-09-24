namespace Infrastructure.Interfaces.Tenant;
public interface ITenantRepository : IRepository<TenantEntity>
{
     Task<bool> IsExistsByIdAsync(string id, CancellationToken ct);
}
