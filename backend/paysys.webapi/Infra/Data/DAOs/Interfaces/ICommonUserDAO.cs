using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface ICommonUserDAO
{
    Task<IEnumerable<ShortCommonUserTO>> GetShortCommonUsers();
    Task<FullCommonUserTO> GetFullCommonUserById(Guid commonUserId);
    Task<int> GetCommonUsersQuantity();
    Task<double> GetCommonUserBalance(Guid commonUserId);
    Task<double> GetCommonUserBalanceByUserId(Guid userId);
}
