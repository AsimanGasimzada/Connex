using Connex.Core.Enums;

namespace Connex.Business.Services.Abstractions;

public interface ISliderService
{
    Task<bool> CreateAsync(SliderCreateDto dto, ModelStateDictionary ModelState);
    Task<bool?> UpdateAsync(SliderUpdateDto dto, ModelStateDictionary ModelState);
    Task<SliderUpdateDto?> GetUpdatedSlider(int id);
    Task<bool> DeleteAsync(int id);
    Task<SliderGetDto?> GetAsync(int id, Languages language = Languages.Azerbaijan);
    Task<List<SliderGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
}
