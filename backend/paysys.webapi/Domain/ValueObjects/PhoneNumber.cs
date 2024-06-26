using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string? PhoneNumberText { get; init; }

    protected PhoneNumber()
    {
    }

    public PhoneNumber(string phoneNumberText)
    {
        phoneNumberText = StringFormatter.FullyClear(phoneNumberText);

        AddNotifications(new Contract<PhoneNumber>()
            .IsNotNullOrEmpty(phoneNumberText, "PhoneNumber", "O número de telefone não pode ser nulo ou vazio")
            .Matches(phoneNumberText, "^[0-9]{11}$", "PhoneNumber", "O número de telefone é inválido")
        );

        if (!IsValid)
            throw new ArgumentException("Número de telefone inválido");

        PhoneNumberText = phoneNumberText;
    }

    public string GetFormattedPhoneNumber()
    {
        return $"({PhoneNumberText!.Substring(0, 2)}) {PhoneNumberText.Substring(2, 5)}" +
               $"-{PhoneNumberText.Substring(7, 4)}";
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return PhoneNumberText!;
    }
}
