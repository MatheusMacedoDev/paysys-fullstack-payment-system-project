using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Infra.Data.Repositories;

public class TransfersRepository : ITransfersRepository
{
    private readonly DataContext _context;

    public TransfersRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateTransfer(Transfer transfer)
    {
        try
        {
            await _context.Transfers!.AddAsync(transfer);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
