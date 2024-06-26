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

        Assert.True(transfer.TransferDescription!.IsValid);
    }
}
