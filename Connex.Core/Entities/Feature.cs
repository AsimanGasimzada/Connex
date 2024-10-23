namespace Connex.Core.Entities;

public class Feature:BaseEntity
{
    public string ImagePath { get; set; } = null!;
    public ICollection<FeatureDetail> FeatureDetails { get; set; } = [];
}
