using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class CorporateName : ValueObject
{
    public string? NameText { get; init; }

    protected CorporateName()
    {
    }

    public CorporateName(string nameText)
    {
        nameText = StringFormatter.BasicClear(nameText);

        AddNotifications(new Contract<CorporateUserName>()
            .IsNotNullOrEmpty(nameText, "CorporateName", "O nome corporativo não pode ser nula ou vazia")
            .IsLowerOrEqualsThan(nameText, 115, "CorporateName", "O nome corporativo não pode exceder 115 caracteres")
            .Matches(nameText, @"^(\s?[A-Z][a-zA-Z]+\s?)+$", "CorporateName", "Nome corporativo inválido")
        );

        if (!IsValid)
            throw new ArgumentException("Nome corporativo inválido");

        NameText = nameText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return NameText!;
    }
}
