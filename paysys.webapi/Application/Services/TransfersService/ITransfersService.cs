using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;

namespace paysys.webapi.Application.Services.TransfersService;

public interface ITransfersService
{
    CreateTransferStatusResponse CreateTransferStatus(CreateTransferStatusRequest request);
    Task<GetAllTransferStatusResponse> GetAllTransferStatus();

    CreateTransferCategoryResponse CreateTransferCategory(CreateTransferCategoryRequest request);
    Task<GetAllTransferCategoriesResponse> GetAllTransferCategories();

    Task<CreateTransferResponse> CreateTransfer(CreateTransferRequest request);
    Task<GetUserTransferHistoryResponse> GetUserTransferHistory(GetUserTransferHistoryRequest request);
}
