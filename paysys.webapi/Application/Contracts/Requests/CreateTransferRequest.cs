namespace paysys.webapi.Application.Contracts.Requests;

public record CreateTransferRequest(
    string transferDescription,
    double transferAmount,
    Guid transferStatusId,
    Guid transferCategoryId,
    Guid senderUserId,
    Guid receiverUserId
);
