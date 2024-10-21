namespace Connex.Business.Dtos;

public class SubscriberUpdateDto : IDto
{
    public int Id { get; set; }
    public string EmailAddress { get; set; } = null!;
}
