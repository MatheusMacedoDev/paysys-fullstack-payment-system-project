using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface IUserTypesRepository
{
    void CreateUserType(UserType? userType);
    List<UserType>? ListUserTypes();
    UserType? GetUserType(Guid userTypeId);
}
