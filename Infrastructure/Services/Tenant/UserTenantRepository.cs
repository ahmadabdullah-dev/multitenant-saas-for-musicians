namespace Infrastructure.Services.Tenant;

public class UserTenantRepository : Repository<UserTenantEntity> ,IUserTenantRepository
{
    public UserTenantRepository(AppDbContext dbContext) : base(dbContext) { }
}
