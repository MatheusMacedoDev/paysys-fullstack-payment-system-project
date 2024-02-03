using paysys.webapi.Domain.Entities;
using paysys.webapi.Interfaces.Repositories;

namespace paysys.webapi.Infra.Data.Repositories;

public class UserTypesRepository : IUserTypesRepository
{
    private readonly DataContext _context;

    public UserTypesRepository(DataContext context)
    {
        _context = context;
    }

    public void CreateUserType(UserType? userType)
    {
        _context.UserTypes!.Add(userType!);
    }

    public UserType GetUserType(Guid userTypeId)
    {
        var findedUserType = _context.UserTypes!
            .FirstOrDefault(userType => userType.UserTypeId == userTypeId);

        if (findedUserType == null)
            throw new Exception("User type not found");

        return findedUserType;
    }

    public List<UserType> ListUserTypes()
    {
        var userTypeList = _context.UserTypes!.ToList();
        return userTypeList;
    }
}
