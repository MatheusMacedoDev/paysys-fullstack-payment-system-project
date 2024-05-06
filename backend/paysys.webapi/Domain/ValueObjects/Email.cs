using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class Email : ValueObject
{
    public string? EmailText { get; init; }

    protected Email()
    {
    }

    public Email(string emailText)
    {
        emailText = StringFormatter.BasicClear(emailText);

        AddNotifications(new Contract<Email>()
            .IsNotNullOrEmpty(emailText, "Email", "O e-mail não deve ser nulo ou vazio")
            .IsEmail(emailText, "Email", "O e-mail digitado não é válido")
        );

        if (!IsValid)
            throw new ArgumentException("E-mail inválido");

        EmailText = emailText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return EmailText!;
    }
}
