using System.ComponentModel.DataAnnotations;

namespace Connex.Business.Dtos;

public class RegisterDto : IDto
{
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;
}
