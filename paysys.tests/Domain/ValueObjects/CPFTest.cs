using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class CPFTest
{
    [Fact]
    public void CreateValidCPF()
    {
        CPF testedCPF = new CPF("56667288747");

        if (!testedCPF.IsValid)
        {
            foreach (var notification in testedCPF.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedCPF.IsValid);
    }

    [Fact]
    public void CreateInvalidCNPJ()
    {
        Action actual = () => new CPF("123456789123a5");

        Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void GetCPFTest()
    {
        CPF testedCPF = new CPF("53338579837");
        string expectedGettedCPF = "533.385.798-37";

        string gettedCPF = testedCPF.CPFText!;

        Assert.Equal(expectedGettedCPF, gettedCPF);
    }
}
