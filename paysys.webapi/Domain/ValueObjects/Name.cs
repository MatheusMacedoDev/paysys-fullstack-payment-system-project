using Flunt.Validations;

namespace paysys.webapi.Domain.ValueObjects;

public class Name : ValueObject
{
    public string? NameText { get; init; }

    protected Name()
    {
    }

    public Name(string nameText)
    {
        nameText = nameText.Trim();

        AddNotifications(new Contract<Name>()
            .IsNotNullOrEmpty(nameText, "Name", "O nome não deve ser nulo ou vazio")
            .IsGreaterOrEqualsThan(nameText, 8, "Name", "O nome deve ter mais que oito letras")
            .Matches(nameText, @"^[A-Z][a-z]+(\s[A-Z][a-z]+)+$", "Name", "O nome conforme descrito é inválido")
        );

        NameText = nameText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return NameText!;
    }
}
