using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.TransfersService;

public class TransfersService : ITransfersService
{
    private readonly ITransferStatusRepository _transferStatusRepository;
    private readonly IUnityOfWork _unityOfWork;

    public TransfersService(ITransferStatusRepository transferStatusRepository, IUnityOfWork unityOfWork)
    {
        _transferStatusRepository = transferStatusRepository;
        _unityOfWork = unityOfWork;
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
}
