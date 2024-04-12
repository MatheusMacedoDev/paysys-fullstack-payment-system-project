namespace paysys.webapi.Infra.Mail.Service;

public interface IMailInfraService
{
    Task SendMailAsync(MailRequest request);
}
