namespace Connex.Business.Services.Abstractions;

public interface ISettingService
{
    Task<bool> CreateAsync(SettingCreateDto dto, ModelStateDictionary ModelState);
    Task<bool?> UpdateAsync(SettingUpdateDto dto, ModelStateDictionary ModelState);
    Task<SettingUpdateDto?> GetUpdatedSettingAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<SettingGetDto?> GetAsync(int id);
    Task<List<SettingGetDto>> GetAllAsync();
    Task<Dictionary<string, string>> GetAllWithDictionaryAsync();
}
