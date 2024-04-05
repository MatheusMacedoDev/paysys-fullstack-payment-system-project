using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class UserTest
{
    private readonly ICryptographyStrategy _cryptographyStrategy;

    public UserTest()
    {
        _cryptographyStrategy = new CryptographyStrategy();
    }

    [Fact]
    public void CreateUserCorrectly()
    {
        User user = new User(
            userName: "Mathe1",
            email: "matheus.macedo@email.com",
            phoneNumber: "11984236577",
            password: "Matheus@8006",
            userTypeId: Guid.Empty,
            _cryptographyStrategy
        );

        Assert.True(user.UserName!.IsValid);
        Assert.True(user.Email!.IsValid);
        Assert.True(user.PhoneNumber!.IsValid);
        Assert.True(user.Password!.IsValid);
    }
}
