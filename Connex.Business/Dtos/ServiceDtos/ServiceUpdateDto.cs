using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class ServiceUpdateDto : IDto
{
    public int Id { get; set; }

    public string? ImagePath { get; set; }

    public IFormFile? Image { get; set; } 

    [Required(ErrorMessage = "Xidmət məlumatları boş ola bilməz.")]
    public List<ServiceDetailCreateDto> ServiceDetails { get; set; } = new();
}
