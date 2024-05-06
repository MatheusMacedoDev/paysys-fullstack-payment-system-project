using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface ITransfersRepository
{
    Task CreateTransferStatus(TransferStatus status);
    Task<List<TransferStatus>> GetAllTransferStatus();

    Task CreateTransferCategory(TransferCategory category);
    Task<List<TransferCategory>> GetAllTransferCategories();

    Task CreateTransfer(Transfer transfer);
}
