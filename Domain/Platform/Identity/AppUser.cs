using Microsoft.AspNetCore.Identity;

namespace Domain.Platform.Identity;

public class AppUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
}