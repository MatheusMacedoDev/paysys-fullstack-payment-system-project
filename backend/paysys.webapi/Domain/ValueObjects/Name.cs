using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class Name : ValueObject
{
    public string? NameText { get; init; }

    protected Name()
    {
    }

    public Name(string nameText, int maxCharacters = 8)
    {
        nameText = StringFormatter.BasicClear(nameText);

        AddNotifications(new Contract<Name>()
            .IsNotNullOrEmpty(nameText, "Name", "O nome não deve ser nulo ou vazio")
            .IsGreaterOrEqualsThan(nameText, maxCharacters, "Name", "O nome deve ter mais que oito letras")
            .Matches(nameText, @"^(\s?[A-Z]\p{L}+|\s[deaos]+)+$", "Name", "O nome conforme descrito é inválido")
        );

        if (!IsValid)
            throw new ArgumentException("Nome inválido");

        NameText = nameText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return NameText!;
    }
}
