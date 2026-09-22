namespace Infrastructure.Services.Tenant;

public class TenantRepository : Repository<TenantEntity>, ITenantRepository
{
    public TenantRepository(AppDbContext dbContext) : base(dbContext) { }

}
