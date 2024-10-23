using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class CertificateUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImagePath { get; set; }
}

