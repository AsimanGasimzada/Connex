namespace Connex.Core.Entities;

public class ProjectDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Language Language { get; set; } = null!;
    public int LanguageId { get; set; }
    public Project Project { get; set; } = null!;
    public int ProjectId { get; set; }
}