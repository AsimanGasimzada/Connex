
namespace Connex.Business.Services.Implementations;

public class ContactService : IContactService
{
    private readonly ISettingService _settingService;
    private readonly IEmailService _emailService;
    private readonly string _staticFilesPath;
    public ContactService(ISettingService settingService, IEmailService emailService)
    {
        _settingService = settingService;
        _emailService = emailService;
        _staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Connex.Business", "StaticFiles");

    }

    public async Task<ContactDto> GetContactDtoAsync()
    {
        ContactDto dto = new()
        {
            Settings = await _settingService.GetAllWithDictionaryAsync()
        };

        return dto;
    }

    public async Task<bool> SendEmailAsync(ContactDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        string emailBody = await _getTemplateContentAsync(dto, "SendEmailByUser.html");

        await _emailService.SendEmailAsync(new() { Body = emailBody, ToEmail = "info@connex.az", Subject = dto.Subject });

        return true;

    }



    private async Task<string> _getTemplateContentAsync(ContactDto dto, string filename)
    {
        string path = Path.Combine(_staticFilesPath, filename);

        using StreamReader streamReader = new StreamReader(path);
        string result = await streamReader.ReadToEndAsync();

        result = result.Replace("[REPLACE_FULLNAME]", dto.Fullname);
        result = result.Replace("[REPLACE_PHONENUMBER]", dto.PhoneNumber);
        result = result.Replace("[REPLACE_MESSAGE]", dto.Message);
        result = result.Replace("[REPLACE_SUBJECT]", dto.Subject);
        result = result.Replace("[REPLACE_EMAIL]", dto.Email);

        streamReader.Close();
        return result;
    }

}

