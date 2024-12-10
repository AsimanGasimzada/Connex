using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class ProjectCreateDto : IDto
{
    [Required(ErrorMessage = "Şəkil sahəsi boş ola bilməz.")]
    public IFormFile Image { get; set; } = null!;
    public IFormFile? File { get; set; } = null!;

    [Required(ErrorMessage = "Proyekt məlumatları boş ola bilməz.")]
    public List<ProjectDetailCreateDto> ProjectDetails { get; set; } = new();
}
