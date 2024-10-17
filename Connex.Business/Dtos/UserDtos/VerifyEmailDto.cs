namespace Connex.Business.Dtos;

public class VerifyEmailDto : IDto
{
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
}
