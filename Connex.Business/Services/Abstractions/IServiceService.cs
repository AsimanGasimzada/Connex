namespace Connex.Business.Services.Abstractions;

public interface IServiceService : IService<ServiceCreateDto, ServiceUpdateDto>, IGetServiceWithLanguage<ServiceGetDto>
{
}
