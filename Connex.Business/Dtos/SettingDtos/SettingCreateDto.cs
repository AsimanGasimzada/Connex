using System.ComponentModel.DataAnnotations;

namespace Connex.Business.Dtos;

public class SettingCreateDto : IDto
{
    [Required(ErrorMessage = "Açar sahəsi boş ola bilməz.")]
    public string Key { get; set; } = null!;

    [Required(ErrorMessage = "Dəyər sahəsi boş ola bilməz.")]
    public string Value { get; set; } = null!;
}
