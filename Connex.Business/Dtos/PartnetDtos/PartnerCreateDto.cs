using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class PartnerCreateDto : IDto
{
    public string Name { get; set; } = null!;
    public string? OfficialWebsite { get; set; }
    public IFormFile Image { get; set; } = null!;
}

