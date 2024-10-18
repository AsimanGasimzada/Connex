namespace Connex.Business.Services.Abstractions;

public interface IPartnerService
{
    Task<bool> CreateAsync(PartnerCreateDto dto,ModelStateDictionary ModelState);
    Task<bool> UpdateAsync(PartnerUpdateDto dto,ModelStateDictionary ModelState);
    Task<PartnerUpdateDto> GetUpdatedPartnerAsync(int id);
    Task DeleteAsync(int id);
    Task<PartnerGetDto> GetByIdAsync(int id);
    Task<List<PartnerGetDto>> GetAllAsync();
}
