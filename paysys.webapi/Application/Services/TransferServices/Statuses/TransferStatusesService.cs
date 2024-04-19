using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.TransferServices.Statuses;

public class TransferStatusesService : ITransferStatusesService
{
    // Repository
    private readonly ITransfersRepository _transfersRepository;

    // Unity of Work
    private readonly IUnityOfWork _unityOfWork;

    public TransferStatusesService(ITransfersRepository transfersRepository, IUnityOfWork unityOfWork)
    {
        _transfersRepository = transfersRepository;

        _unityOfWork = unityOfWork;
    }

    public CreateTransferStatusResponse CreateTransferStatus(CreateTransferStatusRequest request)
    {
        try
        {
            var transferStatus = new TransferStatus(
                request.transferStatusName
            );

            _transfersRepository.CreateTransferStatus(transferStatus);
            _unityOfWork.Commit();

            var response = new CreateTransferStatusResponse(
                transferStatus.TransferStatusId,
                transferStatus.TransferStatusName!.NameText!
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
            var transferStatusList = await _transfersRepository.GetAllTransferStatus();
            var response = new GetAllTransferStatusResponse(transferStatusList);

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
