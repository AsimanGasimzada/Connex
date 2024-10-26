using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class FeatureCreateDto : IDto
{
    [Required(ErrorMessage = "Şəkil sahəsi boş ola bilməz.")]
    public IFormFile Image { get; set; } = null!;

    [Required(ErrorMessage = "Xüsusiyyət məlumatları boş ola bilməz.")]
    public List<FeatureDetailCreateDto> FeatureDetails { get; set; } = new List<FeatureDetailCreateDto>();
}
