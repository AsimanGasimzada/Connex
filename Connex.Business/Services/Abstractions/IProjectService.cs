namespace Connex.Business.Services.Abstractions;

public interface IProjectService : IService<ProjectCreateDto, ProjectUpdateDto>, IGetServiceWithLanguage<ProjectGetDto>
{
}
