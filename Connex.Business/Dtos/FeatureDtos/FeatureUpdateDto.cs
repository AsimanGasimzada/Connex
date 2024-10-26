using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Connex.Business.Dtos;

public class FeatureUpdateDto : IDto
{
    public int Id { get; set; }
    public IFormFile? Image { get; set; } 
    public string? ImagePath { get; set; }
    [Required(ErrorMessage = "Haqqında məlumatları boş ola bilməz.")]
    public List<FeatureDetailUpdateDto> FeatureDetails { get; set; } = [];
}
