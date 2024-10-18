namespace Connex.Core.Entities;

public class Partner:BaseEntity
{
    public string Name { get; set; } = null!;
    public string? OfficialWebsite { get; set; }
    public string ImagePath { get; set; } = null!;
}
