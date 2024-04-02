using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class NameTest
{
    [Fact]
    public void CreateValidName()
    {
        Name testedName = new Name("Matheus Macedo");

        if (!testedName.IsValid)
        {
            foreach (var notification in testedName.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedName.IsValid);
    }

    [Fact]
    public void CreateInvalidName()
    {
        Action actual = () => new Name("M4theus macedo");

        Assert.Throws<ArgumentException>(actual);
    }
}
