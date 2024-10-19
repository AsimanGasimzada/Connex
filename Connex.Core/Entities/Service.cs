namespace Connex.Core.Entities;

public class Service : BaseEntity
{
    public string ImagePath { get; set; } = null!;
    public ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
}
