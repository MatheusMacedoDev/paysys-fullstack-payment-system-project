using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.TransfersService;

public class TransfersService : ITransfersService
{
    private readonly ITransferStatusRepository _transferStatusRepository;
    private readonly ITransferCategoriesRepository _transferCategoriesRepository;

    private readonly IUnityOfWork _unityOfWork;

    public TransfersService(ITransferStatusRepository transferStatusRepository, ITransferCategoriesRepository transferCategoriesRepository, IUnityOfWork unityOfWork)
    {
        _transferStatusRepository = transferStatusRepository;
        _transferCategoriesRepository = transferCategoriesRepository;
        _unityOfWork = unityOfWork;
    }

    public CreateTransferCategoryResponse CreateTransferCategory(CreateTransferCategoryRequest request)
    {
        try
        {
            var transferCategory = TransferCategory.Create(
                request.transferCategoryName
            );

            _transferCategoriesRepository.CreateTransferCategory(transferCategory);
            _unityOfWork.Commit();

            var response = new CreateTransferCategoryResponse(
                transferCategory.TransferCategoryId,
                transferCategory.TransferCategoryName!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public CreateTransferStatusResponse CreateTransferStatus(CreateTransferStatusRequest request)
    {
        try
        {
            var transferStatus = TransferStatus.Create(
                request.transferStatusName
            );

            _transferStatusRepository.CreateTransferStatus(transferStatus);
            _unityOfWork.Commit();

            var response = new CreateTransferStatusResponse(
                transferStatus.TransferStatusId,
                transferStatus.TransferStatusName!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GetAllTransferStatusResponse> GetAllTransferStatus()
    {
        try
        {
            var transferStatusList = await _transferStatusRepository.GetAllTransferStatus();
            var response = new GetAllTransferStatusResponse(transferStatusList);

            return response;
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
