using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class LanguageCreateDto : IDto
{
    [Required(ErrorMessage = "Kod sahəsi boş ola bilməz.")]
    public string Code { get; set; } = null!;

    [Required(ErrorMessage = "Şəkil sahəsi boş ola bilməz.")]
    public IFormFile Image { get; set; } = null!;
}
