namespace Application.Dtos.Common;

public class CurrentUserDto
{
    public string? Id { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public string? Email { get; set; } 
    public bool EmailConfirmed { get; set; } 
    public string? Role { get; set; } 
}
