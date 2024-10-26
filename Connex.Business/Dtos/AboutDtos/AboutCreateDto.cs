using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class AboutCreateDto : IDto
{
    [Required(ErrorMessage = "Sıra nömrəsi sahəsi boş ola bilməz.")]
    public int OrderNo { get; set; }

    [Required(ErrorMessage = "Şəkil sahəsi boş ola bilməz.")]
    public IFormFile Image { get; set; } = null!;

    [Required(ErrorMessage = "Fon şəkli sahəsi boş ola bilməz.")]
    public IFormFile BGImage { get; set; } = null!;

    [Required(ErrorMessage = "Haqqında məlumatları boş ola bilməz.")]
    public List<AboutDetailCreateDto> AboutDetails { get; set; } = new List<AboutDetailCreateDto>();
}
