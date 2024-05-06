using paysys.webapi.Infra.Mail.Templates;

namespace paysys.webapi.Infra.Mail.Requests;

public record MailWithTemplateRequest(
    string? ReceiverEmail,
    IMailTemplate MailTemplate
);
