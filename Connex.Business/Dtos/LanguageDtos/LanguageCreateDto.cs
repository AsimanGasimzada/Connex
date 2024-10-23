using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class LanguageCreateDto : IDto
{
    public string Code { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
}
