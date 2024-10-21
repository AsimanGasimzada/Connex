namespace Connex.Business.Dtos;

public class SubscriberCreateDto : IDto
{
    public string EmailAddress { get; set; } = null!;
}
