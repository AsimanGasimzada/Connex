namespace Connex.Business.Dtos;

public class SubscriberGetDto : IDto
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = null!;
}
