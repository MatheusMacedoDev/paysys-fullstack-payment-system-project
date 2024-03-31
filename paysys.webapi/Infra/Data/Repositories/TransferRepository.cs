using Microsoft.EntityFrameworkCore;
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

    public async Task CreateTransferStatus(TransferStatus status)
    {
        try
        {
            await _context.TransferStatus!.AddAsync(status);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<TransferStatus>> GetAllTransferStatus()
    {
        try
        {
            return await _context.TransferStatus!.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CreateTransferCategory(TransferCategory category)
    {
        try
        {
            await _context.TransferCategories!.AddAsync(category);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<TransferCategory>> GetAllTransferCategories()
    {
        try
        {
            return await _context.TransferCategories!.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
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
