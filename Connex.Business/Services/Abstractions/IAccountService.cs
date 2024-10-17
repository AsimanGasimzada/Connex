namespace Connex.Business.Services.Abstractions;

public interface IAccountService
{
    public Task<bool> RegisterAsync(RegisterDto dto,ModelStateDictionary ModelState);
    public Task<bool> LoginAsync(LoginDto dto,ModelStateDictionary ModelState);
    public Task<bool> LogoutAsync();
    public Task<bool> VerifyEmailAsync(VerifyEmailDto dto,ModelStateDictionary ModelState);
    public Task<List<UserGetDto>> GetAllUserAsync(); 
    public Task<bool> ChangeUserRoleAsync(UserChangeRoleDto dto);
}
