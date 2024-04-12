using paysys.webapi.Infra.Mail.Templates;

namespace paysys.webapi.Infra.Mail.Service;

public interface IMailInfraService
{
    Task SendMailAsync(MailRequest request);
    Task SendMailWithTemplateAsync(string receiverEmail, IMailTemplate mailTemplate);
}
