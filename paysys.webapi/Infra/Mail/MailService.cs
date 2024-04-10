using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using paysys.webapi.Configuration;

namespace paysys.webapi.Infra.Mail;

public class MailService : IMailService
{
    private readonly SmtpSettings _smtpSettings;

    public MailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendMailAsync(MailRequest request)
    {
        try
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            message.To.Add(MailboxAddress.Parse(request.ReceiverEmail));
            message.Subject = request.MailSubject;
            message.Body = BuildMailBody(request.MailBody!);

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(_smtpSettings.SmtpServer, _smtpSettings.Port);
                await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private MimeEntity BuildMailBody(string htmlBody)
    {
        try
        {
            var builder = new BodyBuilder();

            builder.HtmlBody = htmlBody;

            return builder.ToMessageBody();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
