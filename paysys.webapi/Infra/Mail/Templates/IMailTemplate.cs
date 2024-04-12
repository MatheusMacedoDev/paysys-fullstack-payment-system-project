namespace paysys.webapi.Infra.Mail.Templates;

public interface IMailTemplate
{
    public string Subject { get; }
    public string GenerateEmailBody();
}
