using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface IShopkeeperDAO
{
    Task<IEnumerable<ShortShopkeeperTO>> GetShortShopkeepers();
    Task<int> GetShopkeepersQuantity();
    Task<FullShopkeeperTO> GetFullShopkeeperById(Guid shopkeeperId);
    Task<double> GetShopkeeperBalanceByUserId(Guid userId);
}
