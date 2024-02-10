using paysys.webapi.Application.Strategies.Cryptography;

namespace paysys.tests.Application.Strategies.Cryptography;

public class CryptographyTest
{
    private readonly ICryptographyStrategy _cryptographyStrategy;

    public CryptographyTest()
    {
        _cryptographyStrategy = new CryptographyStrategy();
    }

    [Fact]
    public void MatchingPasswords()
    {
        string password = "MyPassword123";
        string matchingPassword = "MyPassword123";

        var salt = _cryptographyStrategy.MakeSalt();

        var hashedPassword = _cryptographyStrategy.MakeHashedPassword(password, salt);

        Assert.True(_cryptographyStrategy.VerifyHashedPassword(matchingPassword, hashedPassword, salt));
    }

    [Fact]
    public void UnmatchingPasswords()
    {
        string password = "MyPassword123";
        string matchingPassword = "IncorrectPassword324";

        var salt = _cryptographyStrategy.MakeSalt();

        var hashedPassword = _cryptographyStrategy.MakeHashedPassword(password, salt);

        Assert.False(_cryptographyStrategy.VerifyHashedPassword(matchingPassword, hashedPassword, salt));
    }
}
