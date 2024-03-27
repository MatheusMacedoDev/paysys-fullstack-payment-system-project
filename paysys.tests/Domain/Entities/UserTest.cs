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
            password: "12345",
            userTypeId: Guid.Empty,
            _cryptographyStrategy
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
        User user = new User(
            userName: "009487",
            email: "matheus.macedo@email.com",
            phoneNumber: "11984236577",
            password: "12345",
            userTypeId: Guid.Empty,
            _cryptographyStrategy
        );

        var isUserNameInvalid = IsUserPropertyInvalid(user, "UserName");

        Assert.True(isUserNameInvalid);
        Assert.False(user.IsValid);
    }

    [Fact]
    public void CreateUserWithIncorrectEmail()
    {
        User user = new User(
            userName: "009487",
            email: "matheus.macedo",
            phoneNumber: "11984236577",
            password: "12345",
            userTypeId: Guid.Empty,
            _cryptographyStrategy
        );

        var isEmailInvalid = IsUserPropertyInvalid(user, "Email");

        Assert.True(isEmailInvalid);
        Assert.False(user.IsValid);
    }

    [Fact]
    public void CreateUserWithIncorrectPhoneNumber()
    {
        User user = new User(
            userName: "009487",
            email: "matheus.macedo",
            phoneNumber: "1198423657A",
            password: "12345",
            userTypeId: Guid.Empty,
            _cryptographyStrategy
        );

        var isPhoneNumberInvalid = IsUserPropertyInvalid(user, "PhoneNumber");

        Assert.True(isPhoneNumberInvalid);
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
}
