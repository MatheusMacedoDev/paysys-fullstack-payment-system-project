using Flunt.Validations;
using paysys.webapi.Application.Strategies.Cryptography;

namespace paysys.webapi.Domain.ValueObjects;

public class Password : ValueObject
{
    public byte[]? Hash { get; private set; }
    public byte[]? Salt { get; private set; }

    protected Password()
    {
    }

    public Password(string passwordText, ICryptographyStrategy cryptographyStrategy)
    {
        AddPasswordValidations(passwordText);

        if (!IsValid)
            throw new ArgumentException("Senha digitada inválida");

        Salt = cryptographyStrategy.MakeSalt();
        Hash = cryptographyStrategy.MakeHashedPassword(passwordText, Salt);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Hash!;
        yield return Salt!;
    }

    private void AddPasswordValidations(string passwordText)
    {
        AddNotifications(new Contract<Password>()
            .IsNotNullOrEmpty(passwordText, "Password", "A senha não pode ser nula ou vazia")
            .IsGreaterOrEqualsThan(passwordText, 10, "Password", "A senha deve conter ao menos dez caracteres")
            .Matches(passwordText, @"[0-9]+", "Password", "A senha deve conter ao menos um número")
            .Matches(passwordText, @"[a-z]+", "Password", "A senha deve conter ao menos um letra minúscula")
            .Matches(passwordText, @"[A-Z]+", "Password", "A senha deve conter ao menos um letra minúscula")
            .Matches(passwordText, @"[^a-zA-Z0-9]+", "Password", "A senha deve conter ao menos um caractere especial")
        );
    }
}
