namespace paysys.webapi.Application.Contracts.Requests;

public record GetFullTransferRequest
(
    Guid transferId,
    Guid userId
);
