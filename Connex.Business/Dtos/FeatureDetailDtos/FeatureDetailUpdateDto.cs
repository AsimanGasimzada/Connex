namespace Connex.Business.Dtos;

public class FeatureDetailUpdateDto : IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageId { get; set; }
}
