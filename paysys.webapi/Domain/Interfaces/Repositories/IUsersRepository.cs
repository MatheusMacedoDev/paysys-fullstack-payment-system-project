using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface IUsersRepository
{
    void CreateUser(User user);
    User GetUserById(Guid userId);
    void DeleteUser(Guid userId);

    void CreateAdministratorUser(AdministratorUser administrator);
    AdministratorUser GetAdministratorById(Guid administratorId);
    void DeleteAdministrator(Guid administratorId);
}
