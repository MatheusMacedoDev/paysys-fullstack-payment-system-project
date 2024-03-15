using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface ITransferCategoriesRepository
{
    Task CreateTransferCategory(TransferCategory category);
}
