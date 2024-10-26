using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class PartnerCreateDto : IDto
{
    [Required(ErrorMessage = "Ad sahəsi boş ola bilməz.")]
    public string Name { get; set; } = null!;

    public string? OfficialWebsite { get; set; }

    [Required(ErrorMessage = "Şəkil sahəsi boş ola bilməz.")]
    public IFormFile Image { get; set; } = null!;
}

