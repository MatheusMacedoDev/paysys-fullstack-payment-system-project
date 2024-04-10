namespace paysys.webapi.Infra.Mail;

public interface IMailService
{
    Task SendMailAsync(MailRequest request);
}
