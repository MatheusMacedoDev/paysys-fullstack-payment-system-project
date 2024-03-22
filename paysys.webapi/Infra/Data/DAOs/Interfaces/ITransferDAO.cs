using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface ITransferDAO
{
    Task<IEnumerable<UserTransferHistoryItemTO>> GetUserTransferHistory(Guid userId);
    Task<FullTransferTO> GetFullTransfer(Guid transferId, Guid userId);
}
