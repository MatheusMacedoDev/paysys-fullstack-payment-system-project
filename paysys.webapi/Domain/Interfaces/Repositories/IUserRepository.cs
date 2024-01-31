using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Interfaces.Repositories;

public interface IUserRepository
{
    void CreateUserType();
    List<UserType> ListUserTypes();
    UserType GetUserType();
}
