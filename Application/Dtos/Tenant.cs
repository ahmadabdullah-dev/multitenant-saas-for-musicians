namespace Application.Dtos;

public class CreateTenantDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
