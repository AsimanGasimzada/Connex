using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class PartnerUpdateDto : IDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad sahəsi boş ola bilməz.")]
    public string Name { get; set; } = null!;

    public string? OfficialWebsite { get; set; }

    public IFormFile? Image { get; set; }

    public string? ImagePath { get; set; }
}
