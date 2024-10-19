namespace Connex.Core.Entities;

public class Language:BaseEntity
{
    public string Code { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public bool IsDefault { get; set; } = false;
    public ICollection<SliderDetail> SliderDetails { get; set; } = new List<SliderDetail>();
    public ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();

}
