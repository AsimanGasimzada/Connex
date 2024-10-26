using System.ComponentModel.DataAnnotations;

namespace Connex.Business.Dtos;

public class SliderDetailCreateDto : IDto
{
    [Required(ErrorMessage = "Başlıq sahəsi boş ola bilməz.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Alt başlıq sahəsi boş ola bilməz.")]
    public string Subtitle { get; set; } = null!;

    [Required(ErrorMessage = "Təsvir sahəsi boş ola bilməz.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Düymə başlığı sahəsi boş ola bilməz.")]
    public string ButtonTitle { get; set; } = null!;

    [Required(ErrorMessage = "Dil ID sahəsi boş ola bilməz.")]
    public int LanguageId { get; set; }
}
