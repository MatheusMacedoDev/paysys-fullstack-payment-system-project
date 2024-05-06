using paysys.webapi.Infra.Data.DAOs.TransferObjects;

namespace paysys.webapi.Infra.Data.DAOs.Interfaces;

public interface IUserDAO
{
    Task<UserForLoginTO> GetUserByEmail(string userEmail);
    Task<IEnumerable<UserForSearchTO>> GetUsersByNameOrUsername(string searchedText);
}
