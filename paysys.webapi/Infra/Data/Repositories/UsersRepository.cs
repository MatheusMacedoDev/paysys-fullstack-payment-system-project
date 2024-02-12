using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Infra.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DataContext _context;

    public UsersRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateAdministratorUser(AdministratorUser administrator)
    {
        await _context.AdministratorUsers!.AddAsync(administrator);
    }

    public Task<AdministratorUser> GetAdministratorById(Guid administratorId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAdministrator(Guid administratorId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateUser(User user)
    {
        await _context.Users!.AddAsync(user);
    }

    public Task<User> GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task CreateCommonUser(CommonUser commonUser)
    {
        throw new NotImplementedException();
    }

    public Task<CommonUser> GetCommonUserById(Guid commonUserId)
    {
        throw new NotImplementedException();
    }
}
