namespace Connex.Business.Services.Abstractions;

public interface IFeatureService : IService<FeatureCreateDto, FeatureUpdateDto>, IGetServiceWithLanguage<FeatureGetDto>
{
}
