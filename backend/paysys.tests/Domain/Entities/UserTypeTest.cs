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

        Assert.True(userType.TypeName!.IsValid);
    }
}
