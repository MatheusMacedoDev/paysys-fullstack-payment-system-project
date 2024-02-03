using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Interfaces.Repositories;

public interface IUserTypesRepository
{
    void CreateUserType();
    List<UserType> ListUserTypes();
    UserType GetUserType();
}
