using System.ComponentModel.DataAnnotations;

namespace Connex.Business.Dtos;

public class SettingUpdateDto : IDto
{
    [Required(ErrorMessage = "ID sahəsi boş ola bilməz.")]
    public int Id { get; set; }

    public string? Key { get; set; }

    [Required(ErrorMessage = "Dəyər sahəsi boş ola bilməz.")]
    public string Value { get; set; } = null!;
}
