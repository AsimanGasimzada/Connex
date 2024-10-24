namespace Connex.Business.Services.Abstractions;

public interface IContactService
{
    Task<ContactDto> GetContactDtoAsync();
    Task<bool> SendEmailAsync(ContactDto dto, ModelStateDictionary ModelState);
}
