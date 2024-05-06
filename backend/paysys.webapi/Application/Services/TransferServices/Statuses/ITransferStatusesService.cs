using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;

namespace paysys.webapi.Application.Services.TransferServices.Statuses;

public interface ITransferStatusesService
{
    CreateTransferStatusResponse CreateTransferStatus(CreateTransferStatusRequest request);
    Task<GetAllTransferStatusResponse> GetAllTransferStatus();
}
