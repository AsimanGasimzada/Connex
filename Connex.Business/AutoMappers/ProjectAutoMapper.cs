using AutoMapper;

namespace Connex.Business.AutoMappers;

public class ProjectAutoMapper : Profile
{
    public ProjectAutoMapper()
    {
        CreateMap<Project, ProjectCreateDto>().ReverseMap();
        CreateMap<Project, ProjectUpdateDto>().ReverseMap().ForMember(x => x.ImagePath, x => x.Ignore());

        CreateMap<Project, ProjectGetDto>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProjectDetails.FirstOrDefault()!.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProjectDetails.FirstOrDefault()!.Description));
    }
}
