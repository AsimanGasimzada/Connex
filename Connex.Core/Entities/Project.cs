namespace Connex.Core.Entities;

public class Project : BaseEntity
{
    public string ImagePath { get; set; } = null!;
    public string? FilePath { get; set; }
    public ICollection<ProjectDetail> ProjectDetails { get; set; } = new List<ProjectDetail>();

}

