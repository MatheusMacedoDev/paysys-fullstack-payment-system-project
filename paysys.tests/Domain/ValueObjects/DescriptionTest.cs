using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class NameTest
{
    [Fact]
    public void CreateValidName()
    {
        Description testedDescription = new Description("Realizando um pagamento atrazado.");

        if (!testedDescription.IsValid)
        {
            foreach (var notification in testedDescription.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedDescription.IsValid);
    }

    [Fact]
    public void CreateInvalidName()
    {
        Action actual = () => new Description("Realiz4ndo um pag4mento atrazado.");

        Assert.Throws<ArgumentException>(actual);
    }
}
