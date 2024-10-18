namespace Connex.Core.Entities;

public class Slider : BaseEntity
{
    public string ImagePath { get; set; } = null!;
    public ICollection<SliderDetail> SliderDetails { get; set; } = new List<SliderDetail>();
}
