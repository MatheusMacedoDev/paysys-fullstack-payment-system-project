namespace paysys.webapi.Application.Contracts.Responses;

public record CreateTransferResponse
(
    Guid transferId,
    string transferDescription,
    double transferAmount,
    DateTime transferDateTime,
    Guid transferStatusId,
    Guid transferCategoryId,
    Guid senderUserId,
    Guid receiverUserId
);
