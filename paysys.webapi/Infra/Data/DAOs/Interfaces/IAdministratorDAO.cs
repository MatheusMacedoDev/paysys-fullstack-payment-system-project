using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface IAdministratorDAO
{
    Task<int> GetAdministratorsQuantity();
    Task<IEnumerable<ShortAdministratorTO>> GetShortAdministrators();
}
