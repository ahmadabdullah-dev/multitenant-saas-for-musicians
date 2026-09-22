using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Tenant;

public class UserTenantConfiguration : IEntityTypeConfiguration<UserTenantEntity>
{
    public void Configure(EntityTypeBuilder<UserTenantEntity> builder)
    {
        builder.HasKey(ut => new { ut.Id });

        builder.HasOne(ut => ut.User)
         .WithMany(u => u.UserTenants)
         .HasForeignKey(ut => ut.UserId);

        builder.HasOne(ut => ut.Tenant)
         .WithMany(t => t.UserTenants)
         .HasForeignKey(ut => ut.TenantId);
    }
}
