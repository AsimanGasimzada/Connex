using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class SliderUpdateDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Subtitle { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ButtonTitle { get; set; } = null!;
    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }
}
