namespace Connex.Business.Services.Abstractions;

public interface ISubscriberService : IService<SubscriberCreateDto, SubscriberUpdateDto>, IGetService<SubscriberGetDto>
{
    Task<bool> SendEmailToSubscribres(SubscriberEmailDto dto,ModelStateDictionary ModelState);
}
