namespace Connex.Core.Entities;

public class Language : BaseEntity
{
    public string Code { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public bool IsDefault { get; set; } = false;
    public ICollection<SliderDetail> SliderDetails { get; set; } = [];
    public ICollection<ServiceDetail> ServiceDetails { get; set; } = [];
    public ICollection<ProjectDetail> ProjectDetails { get; set; } = [];
    public ICollection<AboutDetail> AboutDetails { get; set; } = [];
    public ICollection<FeatureDetail> FeatureDetails { get; set; } = [];

}
