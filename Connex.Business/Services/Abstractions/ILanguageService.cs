namespace Connex.Business.Services.Abstractions;

public interface ILanguageService : IService<LanguageCreateDto, LanguageUpdateDto>, IGetService<LanguageGetDto>
{
    Task<LanguageGetDto> GetWithCodeAsync(string code);
}
