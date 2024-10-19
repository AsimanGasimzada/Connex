using AutoMapper;

namespace Connex.Business.AutoMappers;

public class ProjectDetailAutoMapper : Profile
{
    public ProjectDetailAutoMapper()
    {
        CreateMap<ProjectDetail, ProjectDetailCreateDto>().ReverseMap();
        CreateMap<ProjectDetail, ProjectDetailUpdateDto>().ReverseMap();
    }
}
