namespace Connex.Business.Dtos;

public class LoginDto : IDto
{
    public string EmailOrUsername { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? ReturnUrl { get; set; }
}
