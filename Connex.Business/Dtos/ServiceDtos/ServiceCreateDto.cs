using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class ServiceCreateDto : IDto
{
    public IFormFile Image { get; set; } = null!;
    public List<ServiceDetailCreateDto> ServiceDetails { get; set; } = new();
}
