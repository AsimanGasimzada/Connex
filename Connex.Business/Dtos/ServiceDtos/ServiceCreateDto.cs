using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class ServiceCreateDto : IDto
{
    [Required(ErrorMessage = "Şəkil sahəsi boş ola bilməz.")]
    public IFormFile Image { get; set; } = null!;

    [Required(ErrorMessage = "Xidmət məlumatları boş ola bilməz.")]
    public List<ServiceDetailCreateDto> ServiceDetails { get; set; } = new();
}
