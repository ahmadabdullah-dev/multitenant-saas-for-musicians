using Microsoft.AspNetCore.Identity;

namespace Domain.Common.Identity;

public class AppUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? TenantId { get; set; }  // null = staff, Guid = tenant user
    public bool IsSystemAdmin { get; set; }
    public DateTime CreatedAt { get; set; }
}