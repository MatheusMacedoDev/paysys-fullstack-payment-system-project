using Flunt.Validations;
using paysys.webapi.Utils;

namespace paysys.webapi.Domain.ValueObjects;

public class UserName : ValueObject
{
    public string? NameText { get; init; }

    protected UserName()
    {
    }

    public UserName(string nameText)
    {
        nameText = StringFormatter.BasicClear(nameText);

        AddNotifications(new Contract<UserName>()
            .IsNotNullOrEmpty(nameText, "UserName", "O nome de usuário não deve ser nulo ou vazio")
            .IsGreaterThan(nameText, 5, "UserName", "O nome de usuário deve conter mais de cinco carácteres")
            .Matches(nameText, "^[A-Za-z][a-zA-Z0-9-_.]+$", "UserName", "O nome de usuário deve conter letras")
        );

        if (!IsValid)
            throw new ArgumentException("Nome de usuário inválido");

        NameText = nameText;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return NameText!;
    }
}
