using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class TransferStatusTest
{
    [Fact]
    public void CreateTransferStatusCorrectly()
    {
        var status = new TransferStatus(
            transferStatusName: "Concluida"
        );

        if (!status.IsValid)
        {
            foreach (var notification in status.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(status.IsValid);
    }

    [Fact]
    public void CreateTransferStatusWithIncorrectStatusName()
    {
        var status = new TransferStatus(
            transferStatusName: "C0ncluíd4"
        );

        var isStatusNameInvalid = IsStatusPropertyInvalid(status, "TransferStatusName");

        Assert.True(isStatusNameInvalid);
        Assert.False(status.IsValid);
    }

    private bool IsStatusPropertyInvalid(TransferStatus status, string propertyName)
    {
        if (!status.IsValid)
        {
            foreach (var notification in status.Notifications)
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
