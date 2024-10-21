using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class AboutCreateDto : IDto
{
    public int OrderNo { get; set; }
    public IFormFile Image { get; set; } = null!;
    public IFormFile BGImage { get; set; } = null!;
    public List<AboutDetailCreateDto> AboutDetails { get; set; } = [];
}
