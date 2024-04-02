using Flunt.Validations;

namespace paysys.webapi.Domain.ValueObjects;

public class CPF : ValueObject
{
    public string? CPFText { get; init; }

    protected CPF()
    {
    }

    public CPF(string cpfText)
    {
        cpfText = cpfText.Trim();

        AddNotifications(new Contract<CPF>()
            .IsNotNullOrEmpty(cpfText, "CPF", "O CPF não deve ser nulo ou vazio")
            .Matches(cpfText, @"^\d{11}$", "CPF", "O CPF conforme descrito é inválido")
        );

        if (!IsValid)
            throw new ArgumentException("CPF inválido");

        CPFText = cpfText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CPFText!;
    }
}
