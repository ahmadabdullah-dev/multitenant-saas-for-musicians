namespace Application.Dtos.Staff;

public class StaffLoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool RememberMe { get; set; } = false;
}