namespace paysys.webapi.Application.Contracts.Requests;

public record GetUserTransferHistoryRequest(
    Guid userId
);
