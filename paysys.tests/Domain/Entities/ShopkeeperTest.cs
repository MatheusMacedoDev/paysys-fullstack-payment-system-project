using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class ShopkeeperTest
{
    [Fact]
    public void CreateShopkeeperCorrectly()
    {
        var shopkeeper = new Shopkeeper(
            fancyName: "Contabilizei",
            companyName: "Contabilizei Contabilidade LTDA",
            shopkeeperCNJP: "1234567891234",
            userId: Guid.Empty
        );

        if (!shopkeeper.IsValid)
        {
            foreach (var notification in shopkeeper.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(shopkeeper.IsValid);
    }

    [Fact]
    public void CreateShopkeeperWithIncorrectFancyName()
    {
        var shopkeeper = new Shopkeeper(
            fancyName: "Contabilizei empresa",
            companyName: "Contabilizei Contabilidade LTDA",
            shopkeeperCNJP: "1234567891234",
            userId: Guid.Empty
        );

        var isFancyNameInvalid = IsUserPropertyInvalid(shopkeeper, "FancyName");

        Assert.True(isFancyNameInvalid);
        Assert.False(shopkeeper.IsValid);
    }

    [Fact]
    public void CreateShopkeeperWithIncorrectCompanyName()
    {
        var shopkeeper = new Shopkeeper(
            fancyName: "Contabilizei empresa",
            companyName: "Contabilizei Contabilidade lTDA",
            shopkeeperCNJP: "1234567891234",
            userId: Guid.Empty
        );

        var isCompanyNameInvalid = IsUserPropertyInvalid(shopkeeper, "CompanyName");

        Assert.True(isCompanyNameInvalid);
        Assert.False(shopkeeper.IsValid);
    }

    private bool IsUserPropertyInvalid(Shopkeeper shopkeeper, string propertyName)
    {
        if (!shopkeeper.IsValid)
        {
            foreach (var notification in shopkeeper.Notifications)
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
