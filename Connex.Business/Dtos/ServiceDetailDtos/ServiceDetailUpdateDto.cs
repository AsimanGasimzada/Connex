namespace Connex.Business.Dtos;

public class ServiceDetailUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageId { get; set; }
}
