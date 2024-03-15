using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Infra.Data.Repositories;

public class TransferCategoriesRepository : ITransferCategoriesRepository
{
    private readonly DataContext _context;

    public TransferCategoriesRepository(DataContext context)
    {
        _context = context;
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
}
