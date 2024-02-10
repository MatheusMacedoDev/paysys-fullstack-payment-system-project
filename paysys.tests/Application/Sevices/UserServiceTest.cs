using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.tests.Application.Services;

public class UserServiceTest
{
    private readonly UsersService _usersService;
    private readonly IUsersRepository _usersRepository;

    public UserServiceTest()
    {
        _usersRepository = new MemoryUsersRepository();

        IUnityOfWork unityOfWork = new FakeUnityOfWork();
        ICryptographyStrategy cryptographyStrategy = new CryptographyStrategy();

        _usersService = new UsersService(_usersRepository, unityOfWork, cryptographyStrategy);
    }

    [Fact]
    public void CreateAdministrator()
    {
        var request = new CreateAdministratorRequest(
            "Matheus Macedo Santos",
            "34448759843",
            "Math21",
            "matheus@email.com",
            "11983425488",
            "12345",
            Guid.NewGuid()
        );

        var response = _usersService.CreateAdministrator(request);

        var memoryUserEmail = _usersRepository.GetUserById(response.userId).Email;
        var memoryAdministratorName = _usersRepository.GetAdministratorById(response.administratorId).AdministratorName;

        Assert.Equal("matheus@email.com", memoryUserEmail);
        Assert.Equal("Matheus Macedo Santos", memoryAdministratorName);
    }
}

public class MemoryUsersRepository : IUsersRepository
{
    private List<User> Users = new List<User>();
    private List<AdministratorUser> AdministratorUsers = new List<AdministratorUser>();

    public void CreateAdministratorUser(AdministratorUser administrator)
    {
        AdministratorUsers.Add(administrator);
    }

    public void CreateUser(User user)
    {
        Users.Add(user);
    }

    public void DeleteAdministrator(Guid administratorId)
    {
        var administrator = GetAdministratorById(administratorId);
        AdministratorUsers.Remove(administrator);
    }

    public void DeleteUser(Guid userId)
    {
        var user = GetUserById(userId);
        Users.Remove(user);
    }

    public AdministratorUser GetAdministratorById(Guid administratorId)
    {
        foreach (AdministratorUser administrator in AdministratorUsers)
        {
            if (administrator.AdministratorId == administratorId)
                return administrator;
        }

        throw new Exception("Administrator not found.");
    }

    public User GetUserById(Guid userId)
    {
        foreach (User user in Users)
        {
            if (user.UserId == userId)
                return user;
        }

        throw new Exception("User not found.");
    }
}

public class FakeUnityOfWork : IUnityOfWork
{
    public Task<bool> Commit()
    {
        return Task<bool>.Factory.StartNew(() => true);
    }

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
