using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class FeatureCreateDto : IDto
{
    public IFormFile Image { get; set; } = null!;
    public List<FeatureDetailCreateDto> FeatureDetails { get; set; } = [];
}
