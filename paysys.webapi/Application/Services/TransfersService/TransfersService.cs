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
    private readonly ITransfersRepository _transfersRepository;

    private readonly IUnityOfWork _unityOfWork;

    public TransfersService(ITransferStatusRepository transferStatusRepository, ITransferCategoriesRepository transferCategoriesRepository, ITransfersRepository transfersRepository, IUnityOfWork unityOfWork)
    {
        _transferStatusRepository = transferStatusRepository;
        _transferCategoriesRepository = transferCategoriesRepository;
        _transfersRepository = transfersRepository;

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

    public async Task<GetAllTransferCategoriesResponse> GetAllTransferCategories()
    {
        try
        {
            var transferCategoriesList = await _transferCategoriesRepository.GetAllTransferCategories();
            var response = new GetAllTransferCategoriesResponse(transferCategoriesList);

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

    public CreateTransferResponse CreateTransfer(CreateTransferRequest request)
    {
        try
        {
            var transfer = Transfer.Create(
                transferDescription: request.transferDescription,
                transferAmount: request.transferAmount,
                transferStatusId: request.transferStatusId,
                transferCategoryId: request.transferCategoryId,
                senderUserId: request.senderUserId,
                receiverUserId: request.receiverUserId
            );

            _transfersRepository.CreateTransfer(transfer);
            _unityOfWork.Commit();

            var response = new CreateTransferResponse(
                transferId: transfer.TransferId,
                transferDescription: transfer.TransferDescription!,
                transferAmount: transfer.TransferAmount,
                transferDateTime: transfer.TransferDateTime,
                transferStatusId: transfer.TransferStatusId,
                transferCategoryId: transfer.TransferCategoryId,
                senderUserId: transfer.SenderUserId,
                receiverUserId: transfer.ReceiverUserId
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
