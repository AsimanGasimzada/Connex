using Connex.Core.Enums;

namespace Connex.Business.Services.Abstractions;

public interface IServiceService
{
    Task<bool> CreateAsync(ServiceCreateDto dto, ModelStateDictionary ModelState);
    Task<bool> UpdateAsync(ServiceUpdateDto dto, ModelStateDictionary ModelState);
    Task<ServiceUpdateDto> GetUpdatedServiceAsync(int id);
    Task DeleteAsync(int id);
    Task<ServiceGetDto> GetByIdAsync(int id, Languages language = Languages.Azerbaijan);
    Task<List<ServiceGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
}
