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

    public void CreateAdministratorUser(AdministratorUser administrator)
    {
        _context.AdministratorUsers!.Add(administrator);
    }

    public AdministratorUser GetAdministratorById(Guid administratorId)
    {
        throw new NotImplementedException();
    }

    public void DeleteAdministrator(Guid administratorId)
    {
        throw new NotImplementedException();
    }

    public void CreateUser(User user)
    {
        _context.Users!.Add(user);
    }

    public User GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}
