namespace Connex.Business.Services.Abstractions;

public interface ISliderService
{
    Task<bool> CreateAsync(SliderCreateDto dto, ModelStateDictionary ModelState);
    Task<bool?> UpdateAsync(SliderUpdateDto dto, ModelStateDictionary ModelState);
    Task<SliderUpdateDto?> GetUpdatedSlider(int id);
    Task<bool> DeleteAsync(int id);
    Task<SliderGetDto?> GetAsync(int id);
    Task<List<SliderGetDto>> GetAllAsync();
}
