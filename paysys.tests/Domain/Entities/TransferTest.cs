using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class TransferTest
{
    [Fact]
    public void CreateTransferCorrectly()
    {
        var transfer = new Transfer(
            transferDescription: "Realizando um pagamento atrazado.",
            transferAmount: 500,
            transferStatusId: Guid.Empty,
            transferCategoryId: Guid.Empty,
            senderUserId: Guid.Empty,
            receiverUserId: Guid.Empty
        );

        if (!transfer.IsValid)
        {
            foreach (var notification in transfer.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(transfer.IsValid);
    }

    [Fact]
    public void CreateTransferCategoryWithIncorrectCategoryName()
    {
        var transfer = new Transfer(
            transferDescription: "Realizando um pagamento atrazado.",
            transferAmount: 500,
            transferStatusId: Guid.Empty,
            transferCategoryId: Guid.Empty,
            senderUserId: Guid.Empty,
            receiverUserId: Guid.Empty
        );

        var isDescriptionInvalid = IsTransferPropertyInvalid(transfer, "TransferDescription");

        Assert.True(isDescriptionInvalid);
        Assert.False(transfer.IsValid);
    }

    private bool IsTransferPropertyInvalid(Transfer transfer, string propertyName)
    {
        if (!transfer.IsValid)
        {
            foreach (var notification in transfer.Notifications)
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
