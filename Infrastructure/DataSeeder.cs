using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class DataSeeder
{
    private readonly UserManager<StaffUser> _staffUserManager;
    private readonly RoleManager<StaffRole> _staffRoleManager;
    private readonly UserManager<TenantUser> _tenantUserManager;
    private readonly RoleManager<TenantRole> _tenantRoleManager;

    public DataSeeder(
        UserManager<TenantUser> tenantUserManager, 
        RoleManager<TenantRole> tenantRoleManager,
        UserManager<StaffUser> staffUserManager,
        RoleManager<StaffRole> staffRoleManager
        
        )
    {
        _tenantRoleManager = tenantRoleManager;
        _tenantUserManager = tenantUserManager;
        _staffUserManager = staffUserManager;
        _staffRoleManager = staffRoleManager;

    }
    public async Task Seed()
    {
        await SeedStaffRoles();
        await SeedStaffUsers();
    }
    
    public async Task SeedStaffRoles()
    {
        var dbRoles = await _staffRoleManager.Roles.ToListAsync();

        var roles = new List<StaffRole>()
        {
            new() {Name = "SuperAdmin"},
            new() {Name = "Admin"},
        };

        foreach(var role in roles)
        {
            if (!dbRoles.Contains(role))
            {
                await  _staffRoleManager.CreateAsync(role);
            }
        }
    }
    public async Task SeedStaffUsers()
    {
        var users = new List<(StaffUser user, string role)>()
        {
            (new() { FirstName = "SuperAdminFN",LastName = "SuperAdminLN"  ,UserName = "superadmin@test.com", Email= "superadmin@test.com", EmailConfirmed = true}, "SuperAdmin"),
            (new() { FirstName = "AdminFN", LastName = "AdminLN" ,UserName = "admin@test.com", Email= "admin@test.com", EmailConfirmed = true}, "Admin"),
        };
        
        foreach (var (user,role) in users)
        {
            var existingUser = await _staffUserManager.FindByNameAsync(user.UserName!);
         
            if (existingUser == null)
            {
                var result = await _staffUserManager.CreateAsync(user,"Pa$$w0rd");       
               
                if(result.Succeeded)
                    await _staffUserManager.AddToRoleAsync(user, role);
            }
        }
    }
}
