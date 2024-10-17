namespace Connex.Business.Dtos;

public class UserChangeRoleDto : IDto
{
    public string UserId { get; set; } = null!;
    public string RoleName { get; set; } = null!;
}