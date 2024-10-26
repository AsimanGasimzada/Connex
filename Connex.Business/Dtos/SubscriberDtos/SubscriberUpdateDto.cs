using System.ComponentModel.DataAnnotations;

namespace Connex.Business.Dtos;

public class SubscriberUpdateDto : IDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "E-poçt ünvanı sahəsi boş ola bilməz.")]
    [EmailAddress(ErrorMessage = "Düzgün e-poçt ünvanı formatı deyil.")]
    public string EmailAddress { get; set; } = null!;
}
