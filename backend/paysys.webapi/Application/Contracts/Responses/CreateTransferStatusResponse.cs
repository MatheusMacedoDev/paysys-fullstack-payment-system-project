namespace paysys.webapi.Application.Contracts.Responses;

public record CreateTransferStatusResponse
(
    Guid transferStatusId,
    string transferStatusName
);
