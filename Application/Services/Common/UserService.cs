using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Application.Services.Common;
public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<UserService> _logger;
    public UserService(
        UserManager<AppUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        ILogger<UserService> logger

    )
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }
    public string? GetCurrentUserId()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
    public string? GetCurrentUserRole()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
    }
    public async Task<Result<CurrentUserDto>> GetCurrentUserAsync()
    {
        var userId = GetCurrentUserId();
        var role = GetCurrentUserRole();

        if (string.IsNullOrEmpty(userId))
            return Result<CurrentUserDto>.Failure("You must be logged in to perform this action.", 403);

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return Result<CurrentUserDto>.Failure("User not found!. It may have been removed or deactivated.", 404);

        var dto = new CurrentUserDto
        {
            Id = userId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            Role = role,
        };
        return Result<CurrentUserDto>.Success(dto);
    }

}
