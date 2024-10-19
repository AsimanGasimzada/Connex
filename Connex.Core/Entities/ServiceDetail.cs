namespace Connex.Core.Entities;

public class ServiceDetail : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Service Service { get; set; } = null!;
    public int ServiceId { get; set; }
    public Language Language { get; set; } = null!;
    public int LanguageId { get; set; }
}
