using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class CPF : ValueObject
{
    private const string UnformattedCPFPattern = @"^\d{11}$";

    public string? CPFText { get; init; }

    protected CPF()
    {
    }

    public CPF(string cpfText)
    {
        cpfText = StringFormatter.FullyClear(cpfText);

        AddNotifications(new Contract<CPF>()
            .IsNotNullOrEmpty(cpfText, "CPF", "O CPF não deve ser nulo ou vazio")
            .Matches(cpfText, UnformattedCPFPattern, "CPF", "O CPF conforme descrito é inválido")
        );

        if (!IsValid)
            throw new ArgumentException("CPF inválido");

        CPFText = cpfText;
    }

    public string GetFormattedCPF()
    {
        return $"{CPFText!.Substring(0, 3)}.{CPFText.Substring(3, 3)}.{CPFText.Substring(6, 3)}-{CPFText.Substring(9, 2)}";
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CPFText!;
    }
}
