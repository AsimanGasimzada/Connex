using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class ServiceUpdateDto : IDto
{
    public int Id { get; set; }
    public string? ImagePath { get; set; } = null!;
    public IFormFile? Image { get; set; } = null!;
    public List<ServiceDetailCreateDto> ServiceDetails { get; set; } = new();
}
