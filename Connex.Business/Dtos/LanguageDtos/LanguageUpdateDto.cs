using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class LanguageUpdateDto : IDto
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string? ImagePath { get; set; }
    public IFormFile? Image { get; set; }
}
