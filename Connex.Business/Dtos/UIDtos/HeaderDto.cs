namespace Connex.Business.Dtos;

public class HeaderDto
{
    public Dictionary<string, string> Settings { get; set; } = [];
    public List<LanguageGetDto> Languages { get; set; } = [];
    public LanguageGetDto SelectedLanguage { get; set; } = null!;
}
