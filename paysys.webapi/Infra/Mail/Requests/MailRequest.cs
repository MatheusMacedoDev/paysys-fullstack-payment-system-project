namespace paysys.webapi.Infra.Mail.Requests;

public record MailRequest(
    string? ReceiverEmail,
    string? MailSubject,
    string? MailBody
);
