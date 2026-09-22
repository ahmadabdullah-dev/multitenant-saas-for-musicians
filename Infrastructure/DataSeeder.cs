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
        await SeedRoles();
        await SeedUsers();
    }

    public async Task SeedRoles()
    {
        var dbRoleNames = await _roleManager.Roles
            .Select(r => r.Name)
            .ToListAsync();

        var roles = new List<AppRole>()
        {
            new() { Name = "StaffSuperAdmin" },
            new() { Name = "StaffAdmin" },
            new() { Name = "TenantSuperAdmin" },
        };

        foreach (var role in roles)
        {
            if (!dbRoleNames.Contains(role.Name))
            {
                var result = await _roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create role '{role.Name}': {errors}");
                }
            }
        }
    }

    public async Task SeedUsers()
    {
        var users = new List<(AppUser user, string role, string password)>()
        {
            (new() { FirstName = "Ahmad", LastName = "Abdullah", UserName = "ahmad", Email = "superadmin@staff.com", EmailConfirmed = true }, "StaffSuperAdmin", "Pa$$w0rd"),
            (new() { FirstName = "Cristiano", LastName = "Ronaldo", UserName = "cr7", Email = "admin@staff.com", EmailConfirmed = true }, "StaffAdmin", "Pa$$w0rd"),
            (new() { FirstName = "Elon", LastName = "Musk", UserName = "elon", Email = "superadmin@tenant.com", EmailConfirmed = true }, "TenantSuperAdmin", "Pa$$w0rd"),
        };

        foreach (var (user, role, password) in users)
        {
            var existingUser = await _userManager.FindByNameAsync(user.UserName!);

            if (existingUser != null)
                continue;

            var createResult = await _userManager.CreateAsync(user, password);

            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create user '{user.UserName}': {errors}");
            }

            var roleResult = await _userManager.AddToRoleAsync(user, role);

            if (!roleResult.Succeeded)
            {
                var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                throw new Exception($"Failed to add user '{user.UserName}' to role '{role}': {errors}");
            }
        }
    }
}