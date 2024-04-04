using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class CorporateNameTest
{
    [Fact]
    public void CreateValidCorporateName()
    {
        CorporateName testedCorporateName = new CorporateName("Contabilizei Contabilidade LTDA");

        if (!testedCorporateName.IsValid)
        {
            foreach (var notification in testedCorporateName.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedCorporateName.IsValid);
    }

    [Fact]
    public void CreateInvalidCorporateName()
    {
        Action actual = () => new CorporateName("Contabilizei Contabilidade lTDA");

        Assert.Throws<ArgumentException>(actual);
    }
}
