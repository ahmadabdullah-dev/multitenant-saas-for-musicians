namespace Application.Dtos.Tenant;

public class TenantLoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool RememberMe { get; set; } = false;
}