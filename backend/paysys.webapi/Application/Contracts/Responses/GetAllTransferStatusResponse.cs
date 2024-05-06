using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Application.Contracts.Responses;

public record GetAllTransferStatusResponse(
    List<TransferStatus> transferStatusList
);
