using paysys.webapi.Infra.Mail.Requests;

namespace paysys.webapi.Infra.Mail.Service;

public interface IMailInfraService
{
    Task SendMailAsync(MailRequest request);
    Task SendMailWithTemplateAsync(MailWithTemplateRequest request);
}
