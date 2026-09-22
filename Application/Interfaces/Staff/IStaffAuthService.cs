namespace Application.Interfaces.Staff;

public interface IStaffAuthService
{
    Task<Result<string>> StaffLoginAsync(StaffLoginDto dto);  
}
