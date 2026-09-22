namespace Application.Interfaces.Common;
public interface IUserService
{
    string? GetCurrentUserId();
    string? GetCurrentUserRole();
    Task<Result<CurrentUserDto>> GetCurrentUserAsync();
}
