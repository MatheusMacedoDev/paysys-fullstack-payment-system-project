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

        Assert.True(status.TransferStatusName!.IsValid);
    }
}
