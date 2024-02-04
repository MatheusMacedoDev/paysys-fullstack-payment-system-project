using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Infra.Data.Repositories;

public class UserTypesRepository : IUserTypesRepository
{
    private readonly DataContext _context;

    public UserTypesRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateUserType(UserType? userType)
    {
        await _context.UserTypes!.AddAsync(userType!);
    }

    public async Task<UserType>? GetUserType(Guid userTypeId)
    {
        var findedUserType = await _context.UserTypes!
            .FirstOrDefaultAsync(userType => userType.UserTypeId == userTypeId);

        if (findedUserType == null)
            throw new Exception("User type not found");

        return findedUserType;
    }

    public async Task<List<UserType>>? ListUserTypes()
    {
        var userTypeList = await _context.UserTypes!.ToListAsync();
        return userTypeList;
    }
}
