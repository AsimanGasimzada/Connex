using System.ComponentModel.DataAnnotations;

namespace Connex.Business.Dtos;

public class ProjectDetailCreateDto : IDto
{
    [Required(ErrorMessage = "Ad sahəsi boş ola bilməz.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Təsvir sahəsi boş ola bilməz.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Dil ID sahəsi boş ola bilməz.")]
    public int LanguageId { get; set; }
}
