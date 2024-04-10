namespace paysys.webapi.Infra.Mail;

public record MailRequest(
    string? ReceiverEmail,
    string? MailSubject,
    string? MailBody
);
