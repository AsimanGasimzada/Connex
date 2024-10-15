using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class SliderCreateDto:IDto
{
    public string Title { get; set; } = null!;
    public string Subtitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ButtonTitle { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
}
