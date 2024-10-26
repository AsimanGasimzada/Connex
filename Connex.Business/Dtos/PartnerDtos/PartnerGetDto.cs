namespace Connex.Business.Dtos;

public class PartnerGetDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? OfficialWebsite { get; set; }
    public string ImagePath { get; set; }=null!;
}

