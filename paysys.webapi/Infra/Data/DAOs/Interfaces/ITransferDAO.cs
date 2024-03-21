using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface ITransferDAO
{
    Task<IEnumerable<CommonUserTransferHistoryItemTO>> GetCommonUserTransferHistory(Guid userId);
}
