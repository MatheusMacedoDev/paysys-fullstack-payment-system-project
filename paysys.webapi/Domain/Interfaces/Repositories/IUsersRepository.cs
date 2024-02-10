using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface IUsersRepository
{
    Task CreateUser(User user);
    Task<User> GetUserById(Guid userId);
    Task DeleteUser(Guid userId);

    Task CreateAdministratorUser(AdministratorUser administrator);
    Task<AdministratorUser> GetAdministratorById(Guid administratorId);
    Task DeleteAdministrator(Guid administratorId);
}
