using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class DataSeeder
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;


    public DataSeeder(
        UserManager<AppUser> userManager, 
        RoleManager<AppRole> roleManager
        )
    {

        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task Seed()
    {
        await SeedUsers();
        await SeedRoles();
    }
    
    public async Task SeedRoles()
    {
        var dbRoles = await _roleManager.Roles.ToListAsync();

        var roles = new List<AppRole>()
        {
            new() {Name = "StaffSuperAdmin"},
            new() {Name = "StaffAdmin"},
            new() {Name = "TenantSuperAdmin"},
        };

        foreach(var role in roles)
        {
            if (!dbRoles.Contains(role))
            {
                await  _roleManager.CreateAsync(role);
            }
        }
    }
    public async Task SeedUsers()
    {
        var users = new List<(AppUser user, string role)>()
        {
            (new() { FirstName = "Ahmad",LastName = "Abdullah", UserName = "ahmad", Email= "superadmin@staff.com", EmailConfirmed = true}, "StaffSuperAdmin"),
            (new() { FirstName = "Cristiano", LastName = "Ronaldo", UserName = "cr7", Email= "admin@staff.com", EmailConfirmed = true}, "StaffAdmin"),
            (new() { FirstName = "Elon",LastName = "Musk", UserName = "elon", Email= "superadmin@tenant.com", EmailConfirmed = true}, "TenantSuperAdmin"),
        };
        
        foreach (var (user,role) in users)
        {
            var existingUser = await _userManager.FindByNameAsync(user.UserName!);
         
            if (existingUser == null)
            {
                var result = await _userManager.CreateAsync(user,"Pa$$w0rd");       
               
                if(result.Succeeded)
                    await _userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
