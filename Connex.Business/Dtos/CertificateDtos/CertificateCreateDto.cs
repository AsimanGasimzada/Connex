using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class CertificateCreateDto : IDto
{
    public IFormFile Image { get; set; } = null!;
}

