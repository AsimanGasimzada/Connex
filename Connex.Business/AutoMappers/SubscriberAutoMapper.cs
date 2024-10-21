using AutoMapper;

namespace Connex.Business.AutoMappers;

public class SubscriberAutoMapper : Profile
{
    public SubscriberAutoMapper()
    {
        CreateMap<Subscriber, SubscriberCreateDto>().ReverseMap().ForMember(x => x.EmailAddress, x => x.MapFrom(x => x.EmailAddress.ToUpper()));
        CreateMap<Subscriber, SubscriberUpdateDto>().ReverseMap().ForMember(x => x.EmailAddress, x => x.MapFrom(x => x.EmailAddress.ToUpper()));
        CreateMap<Subscriber, SubscriberGetDto>().ReverseMap();
    }
}
