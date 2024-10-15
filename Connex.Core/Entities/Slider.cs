namespace Connex.Core.Entities;

public class Slider : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Subtitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ButtonTitle { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
}
