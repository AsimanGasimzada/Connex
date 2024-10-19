namespace Connex.Business.Services.Abstractions;

public interface ISettingService : IService<SettingCreateDto, SettingUpdateDto>, IGetService<SettingGetDto>
{
    Task<Dictionary<string, string>> GetAllWithDictionaryAsync();
}
