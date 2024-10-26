using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class ProjectUpdateDto : IDto
{
    public int Id { get; set; }

    public IFormFile? Image { get; set; }

    public string? ImagePath { get; set; }

    [Required(ErrorMessage = "Proyekt məlumatları boş ola bilməz.")]
    public List<ProjectDetailUpdateDto> ProjectDetails { get; set; } = new();
}
