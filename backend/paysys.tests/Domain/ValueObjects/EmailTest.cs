using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class EmailTest
{
    [Fact]
    public void CreateValidEmail()
    {
        Email testedEmail = new Email("matheus.macedo@email.com");

        if (!testedEmail.IsValid)
        {
            foreach (var notification in testedEmail.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedEmail.IsValid);
    }

    [Fact]
    public void CreateInvalidName()
    {
        Action actual = () => new Email("matheus.macedo");

        Assert.Throws<ArgumentException>(actual);
    }
}
