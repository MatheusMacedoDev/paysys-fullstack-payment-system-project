using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface ITransfersRepository
{
    Task CreateTransfer(Transfer transfer);
}
