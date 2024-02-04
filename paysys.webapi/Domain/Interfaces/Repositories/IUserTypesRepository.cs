using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface IUserTypesRepository
{
    Task CreateUserType(UserType? userType);
    Task<List<UserType>>? ListUserTypes();
    Task<UserType>? GetUserType(Guid userTypeId);
    Task DeleteUserType(Guid userTypeId);
}
