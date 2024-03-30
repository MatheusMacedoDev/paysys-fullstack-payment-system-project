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

        if (!category.IsValid)
        {
            foreach (var notification in category.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(category.IsValid);
    }

    [Fact]
    public void CreateTransferCategoryWithIncorrectCategoryName()
    {
        var category = new TransferCategory(
            transferCategoryName: "Alim3ntos"
        );

        var isCategoryNameInvalid = IsCategoryPropertyInvalid(category, "TransferCategoryName");

        Assert.True(isCategoryNameInvalid);
        Assert.False(category.IsValid);
    }

    private bool IsCategoryPropertyInvalid(TransferCategory category, string propertyName)
    {
        if (!category.IsValid)
        {
            foreach (var notification in category.Notifications)
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
