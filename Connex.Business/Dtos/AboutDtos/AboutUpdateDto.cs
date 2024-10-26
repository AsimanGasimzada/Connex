using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class AboutUpdateDto : IDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Sıra nömrəsi sahəsi boş ola bilməz.")]
    public int OrderNo { get; set; }

    public string? ImagePath { get; set; } = null!;

    public IFormFile? Image { get; set; } = null!;

    public string? BGImagePath { get; set; } = null!;

    public IFormFile? BGImage { get; set; } = null!;

    [Required(ErrorMessage = "Haqqında məlumatları boş ola bilməz.")]
    public List<AboutDetailCreateDto> AboutDetails { get; set; } = new List<AboutDetailCreateDto>();
}
