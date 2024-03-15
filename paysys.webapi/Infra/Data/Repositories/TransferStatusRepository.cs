using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Infra.Data.Repositories;

public class TransferStatusRepository : ITransferStatusRepository
{
    private readonly DataContext _context;

    public TransferStatusRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateTransferStatus(TransferStatus status)
    {
        await _context.TransferStatus!.AddAsync(status);
    }
}
