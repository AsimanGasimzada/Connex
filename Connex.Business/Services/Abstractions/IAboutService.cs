namespace Connex.Business.Services.Abstractions;

public interface IAboutService : IService<AboutCreateDto, AboutUpdateDto>, IGetServiceWithLanguage<AboutGetDto>
{
}
