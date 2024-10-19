using Connex.Core.Enums;

namespace Connex.Business.Services.Abstractions;

public interface IGetServiceWithLanguage<TGetDto> where TGetDto : IDto
{
    Task<TGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan);
    Task<List<TGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan);
}
