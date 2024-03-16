using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface ITransferStatusRepository
{
    Task CreateTransferStatus(TransferStatus status);
    Task<List<TransferStatus>> GetAllTransferStatus();
}
