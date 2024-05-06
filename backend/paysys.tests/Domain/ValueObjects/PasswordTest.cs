using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class PasswordTest
{
    private readonly ICryptographyStrategy _cryptographyStrategy;

    public PasswordTest()
    {
        _cryptographyStrategy = new CryptographyStrategy();
    }

    [Fact]
    public void CreateValidPassword()
    {
        Password testedPassword = new Password("Matheus@8006", _cryptographyStrategy);

        if (!testedPassword.IsValid)
        {
            foreach (var notification in testedPassword.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedPassword.IsValid);
    }

    [Fact]
    public void CreateInvalid()
    {
        Action actual = () => new Password("12345", _cryptographyStrategy);

        Assert.Throws<ArgumentException>(actual);
    }
}
