namespace Application.Dtos.Tenant;

public class CreateTenantDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
public class TenantDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}