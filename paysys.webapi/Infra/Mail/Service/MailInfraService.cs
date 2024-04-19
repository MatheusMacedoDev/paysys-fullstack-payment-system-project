using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using paysys.webapi.Configuration;
using paysys.webapi.Infra.Mail.Requests;

namespace paysys.webapi.Infra.Mail.Service;

public class MailInfraService : IMailInfraService
{
    private readonly SmtpSettings _smtpSettings;
    private readonly bool _disableService;

    public MailInfraService(IOptions<SmtpSettings> smtpSettings, bool disableService = true)
    {
        _smtpSettings = smtpSettings.Value;
        _disableService = disableService;
    }

    public async Task SendMailAsync(MailRequest request)
    {
        if (_disableService)
            return;

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

                await client.ConnectAsync(_smtpSettings.SmtpServer, _smtpSettings.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpSettings.SenderEmail, _smtpSettings.SenderPassword);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public async Task SendMailWithTemplateAsync(MailWithTemplateRequest request)
    {
        var mailRequest = new MailRequest(
            ReceiverEmail: request.ReceiverEmail,
            MailSubject: request.MailTemplate.Subject,
            MailBody: request.MailTemplate.GenerateEmailBody()
        );

        await SendMailAsync(mailRequest);
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
