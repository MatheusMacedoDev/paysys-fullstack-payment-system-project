using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class UserNameTest
{
    [Fact]
    public void CreateValidUserName()
    {
        UserName testedUserName = new UserName("Mathe14");

        if (!testedUserName.IsValid)
        {
            foreach (var notification in testedUserName.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedUserName.IsValid);
    }

    [Fact]
    public void CreateInvalidName()
    {
        Action actual = () => new UserName("009487");

        Assert.Throws<ArgumentException>(actual);
    }
}
