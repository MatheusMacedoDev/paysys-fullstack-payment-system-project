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
        User user = CreateUser(
            userName: "Mathe1",
            email: "matheus.macedo@email.com",
            phoneNumber: "984236577",
            password: "12345",
            userTypeId: Guid.Empty
        );

        Assert.True(user.IsValid);
    }

    [Fact]
    public void CreateUserWithIncorrectUserName()
    {
        User user = CreateUser(
            userName: "009487",
            email: "matheus.macedo@email.com",
            phoneNumber: "984236577",
            password: "12345",
            userTypeId: Guid.Empty
        );

        if (user.IsValid)
        {
            bool isUserNameInvalid = false;

            foreach (var notification in user.Notifications)
            {
                if (notification.Key == "UserName")
                {
                    isUserNameInvalid = true;
                }
            }

            Assert.True(isUserNameInvalid);
        }

        Assert.False(user.IsValid);
    }

    private User CreateUser(string userName, string email, string phoneNumber, string password, Guid userTypeId)
    {
        var salt = _cryptographyStrategy.MakeSalt();
        var hash = _cryptographyStrategy.MakeHashedPassword(password, salt);

        return new User(
            userName,
            email,
            phoneNumber,
            hash,
            salt,
            userTypeId
        );
    }
}
