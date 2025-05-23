﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class SliderUpdateDto : IDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Slider detalları boş ola bilməz.")]
    public List<SliderDetailCreateDto> SliderDetails { get; set; } = new List<SliderDetailCreateDto>();

    public IFormFile? Image { get; set; }

    public string? ImagePath { get; set; }
}
