using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class CNPJTest
{
    [Fact]
    public void CreateValidCNPJ()
    {
        CNPJ testedCNPJ = new CNPJ("12345678912345");

        if (!testedCNPJ.IsValid)
        {
            foreach (var notification in testedCNPJ.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedCNPJ.IsValid);
    }

    [Fact]
    public void CreateInvalidCNPJ()
    {
        Action actual = () => new CNPJ("123456789123a5");

        Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void GetFormattedCNPJ()
    {
        CNPJ testedCNPJ = new CNPJ("12345678912345");
        string expectedGettedCNPJ = "12.345.678/9123-45";

        string gettedCNPJ = testedCNPJ.GetFormattedCNPJ();

        Assert.Equal(expectedGettedCNPJ, gettedCNPJ);
    }
}
