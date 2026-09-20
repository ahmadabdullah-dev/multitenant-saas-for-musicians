using Microsoft.AspNetCore.Identity;

namespace Domain.Platform.Identity;

public class AppRole : IdentityRole
{
    public string? Description { get; set; }
}