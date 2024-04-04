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
            shopkeeperCNJP: "12345678912345",
            userId: Guid.Empty
        );

        Assert.True(shopkeeper.FancyName!.IsValid);
        Assert.True(shopkeeper.CompanyName!.IsValid);
        Assert.True(shopkeeper.ShopkeeperCNJP!.IsValid);
    }
}
