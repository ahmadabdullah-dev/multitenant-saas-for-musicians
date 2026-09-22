using Microsoft.AspNetCore.Identity;

namespace Application.Services.Tenant;

public class TenantAuthService : ITenantAuthService
{
    private readonly UserManager<StaffUser> _userManager;
    private readonly SignInManager<StaffUser> _signInManager;
    public TenantAuthService(UserManager<StaffUser> userManager,
        SignInManager<StaffUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Result<string>> TenantLoginAsync(TenantLoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email.ToLower());

        if (user == null)
            return Result<string>.Failure("Invalid email or password", 401);

        if (await _userManager.IsLockedOutAsync(user))
            return Result<string>.Failure("User is locked. Please reset the password or wait 3 minutes.", 403);

        var loginResult = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

        if (loginResult.IsLockedOut)
            return Result<string>.Failure("User is locked. Please reset the password or wait 3 minutes.", 403);

        if (!loginResult.Succeeded)
            return Result<string>.Failure("Invalid email or password", 401);

        if (user.LockoutEnd != null)
            await _userManager.SetLockoutEndDateAsync(user, null);

        return Result<string>.Success("Logged in successfully");
    }
}
