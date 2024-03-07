using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface IShopkeeperDAO
{
    Task<IEnumerable<ShortShopkeeperTO>> getShortShopkeepers();
    Task<int> getShopkeepersQuantity();
}
