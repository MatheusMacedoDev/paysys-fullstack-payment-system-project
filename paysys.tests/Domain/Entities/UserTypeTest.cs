using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class UserTypeTest
{
    [Fact]
    public void CreateUserTypeCorrectly()
    {
        var userType = new UserType(
            typeName: "Administrador"
        );

        if (!userType.IsValid)
        {
            foreach (var notification in userType.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(userType.IsValid);
    }

    [Fact]
    public void CreateCommonUserWithIncorrectTypeName()
    {
        var userType = new UserType(
            typeName: "Adm1n1str4d0r"
        );

        var isTypeNameInvalid = IsUserTypePropertyInvalid(userType, "TypeName");

        Assert.True(isTypeNameInvalid);
        Assert.False(userType.IsValid);
    }

    private bool IsUserTypePropertyInvalid(UserType userType, string propertyName)
    {
        if (!userType.IsValid)
        {
            foreach (var notification in userType.Notifications)
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
