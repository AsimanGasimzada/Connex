using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;


namespace Connex.Business.Services.Implementations;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly MailKitConfigurationDto _configurationDto;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        _configurationDto = _configuration.GetSection("MailkitOptions").Get<MailKitConfigurationDto>() ?? new();

    }

    public async Task SendEmailAsync(EmailSendDto dto)
    {
        var email = new MimeMessage();

        email.Sender = MailboxAddress.Parse(_configurationDto.Mail);
        email.To.Add(MailboxAddress.Parse(dto.ToEmail));

        email.Subject = dto.Subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = dto.Body;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        smtp.Connect(_configurationDto.Host, int.Parse(_configurationDto.Port), SecureSocketOptions.StartTls);
        smtp.Authenticate(_configurationDto.Mail, _configurationDto.Password);

        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);

    }
}
