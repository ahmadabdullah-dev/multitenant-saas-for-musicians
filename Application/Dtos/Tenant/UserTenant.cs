namespace Application.Dtos.Tenant;

public class AddUserToTenantDto
{
    public required string UserId { get; set; }
    public required string TenantId { get; set; }
}
