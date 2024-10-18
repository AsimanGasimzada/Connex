using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class SliderCreateDto:IDto
{
    public IFormFile Image { get; set; } = null!;
    public List<SliderDetailCreateDto> SliderDetails { get; set; } = new List<SliderDetailCreateDto>();
}
