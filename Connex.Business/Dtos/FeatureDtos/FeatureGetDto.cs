using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class FeatureGetDto : IDto
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
