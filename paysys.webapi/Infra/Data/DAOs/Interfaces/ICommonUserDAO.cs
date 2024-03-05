using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface ICommonUserDAO
{
    Task<IEnumerable<ShortCommonUserTO>> getShortCommonUsers();
}
