using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class SliderCreateDto : IDto
{
    [Required(ErrorMessage = "Şəkil sahəsi boş ola bilməz.")]
    public IFormFile Image { get; set; } = null!;

    [Required(ErrorMessage = "Slider detalları boş ola bilməz.")]
    public List<SliderDetailCreateDto> SliderDetails { get; set; } = new List<SliderDetailCreateDto>();
}
