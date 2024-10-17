namespace Connex.Business.Dtos;

public class SettingUpdateDto : IDto
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}
