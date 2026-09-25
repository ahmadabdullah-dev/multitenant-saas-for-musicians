using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Tenant;

public class TenantRepository : Repository<TenantEntity>, ITenantRepository
{
    public TenantRepository(AppDbContext dbContext) : base(dbContext) { }
    public async Task<bool> IsTenantExistsByIdAsync(string id, CancellationToken ct)
        => await DbSet.AnyAsync(e => e.Id == id, ct);


}
