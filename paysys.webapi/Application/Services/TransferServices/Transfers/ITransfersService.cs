using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;

namespace paysys.webapi.Application.Services.TransferServices.Transfers;

public interface ITransfersService
{
    Task<CreateTransferResponse> CreateTransfer(CreateTransferRequest request);
    Task<GetUserTransferHistoryResponse> GetUserTransferHistory(GetUserTransferHistoryRequest request);
    Task<GetFullTransferResponse> GetFullTransfer(GetFullTransferRequest request);
}
