namespace Connex.Business.Dtos;

public class SettingCreateDto:IDto
{
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;
}
