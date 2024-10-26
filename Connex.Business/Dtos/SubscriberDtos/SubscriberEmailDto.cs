using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class SubscriberEmailDto : IDto
{
    [Required(ErrorMessage = "Mövzu sahəsi boş ola bilməz.")]
    public string Subject { get; set; } = null!;

    [Required(ErrorMessage = "Mətn sahəsi boş ola bilməz.")]
    public string Body { get; set; } = null!;

    public List<IFormFile>? Attachments { get; set; } = new();
}
