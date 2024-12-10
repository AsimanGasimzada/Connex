namespace Connex.Business.Dtos;

public class ProjectGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; }= null!;   
    public string? FilePath { get; set; }= null!;   
}
