using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class PasswordTest
{
    [Fact]
    public void CreateValidPassword()
    {
        Password testedPassword = new Password("Matheus@8006");

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
    public void CreateInvalidPassword()
    {
        Action actual = () => new Password("12345");

        Assert.Throws<ArgumentException>(actual);
    }
}
