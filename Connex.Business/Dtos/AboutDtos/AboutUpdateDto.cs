using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class AboutUpdateDto : IDto
{
    public int Id { get; set; }
    public int OrderNo { get; set; }
    public string? ImagePath { get; set; } = null!;
    public IFormFile? Image { get; set; } = null!;
    public string? BGImagePath { get; set; } = null!;
    public IFormFile? BGImage { get; set; } = null!;
    public List<AboutDetailCreateDto> AboutDetails { get; set; } = [];
}
