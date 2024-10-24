namespace Connex.Business.Dtos;

public class ContactDto:IDto
{
    public Dictionary<string, string>? Settings { get; set; } = [];

    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Message { get; set; } = null!;

}
