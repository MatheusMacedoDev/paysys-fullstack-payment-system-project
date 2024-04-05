using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class TransferCategoryTest
{
    [Fact]
    public void CreateTransferCategoryCorrectly()
    {
        var category = new TransferCategory(
            transferCategoryName: "Alimentos"
        );

        Assert.True(category.TransferCategoryName!.IsValid);
    }
}
