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

        if (!user.IsValid)
        {
            foreach (var notification in user.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

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

        var isUserNameInvalid = IsUserPropertyInvalid(user, "UserName");

        Assert.True(isUserNameInvalid);
        Assert.False(user.IsValid);
    }

    [Fact]
    public void CreateUserWithIncorrectEmail()
    {
        User user = CreateUser(
            userName: "009487",
            email: "matheus.macedo",
            phoneNumber: "984236577",
            password: "12345",
            userTypeId: Guid.Empty
        );

        var isEmailInvalid = IsUserPropertyInvalid(user, "Email");

        Assert.True(isEmailInvalid);
        Assert.False(user.IsValid);
    }

    private bool IsUserPropertyInvalid(User user, string propertyName)
    {
        if (!user.IsValid)
        {
            foreach (var notification in user.Notifications)
            {
                if (notification.Key == propertyName)
                {
                    return true;
                }
            }
        }

        return false;

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
