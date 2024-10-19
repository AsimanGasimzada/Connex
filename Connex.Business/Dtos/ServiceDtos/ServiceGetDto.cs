namespace Connex.Business.Dtos;

public class ServiceGetDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
