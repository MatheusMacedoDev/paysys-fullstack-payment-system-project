using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.tests.Application.Services;

public class UserServiceTest
{
    private readonly IUsersService _usersService;
    private readonly IUsersRepository _usersRepository;

    public UserServiceTest()
    {
        _usersRepository = new MemoryUsersRepository();

        IUnityOfWork unityOfWork = new FakeUnityOfWork();
        ICryptographyStrategy cryptographyStrategy = new CryptographyStrategy();

        _usersService = new UsersService(_usersRepository, unityOfWork, cryptographyStrategy);
    }

    [Fact]
    public async Task CreateAdministrator()
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

        var response = await _usersService.CreateAdministrator(request);

        var memoryUserEmail = (await _usersRepository.GetUserById(response.userId)).Email;
        var memoryAdministratorName = (await _usersRepository.GetAdministratorById(response.administratorId)).AdministratorName;

        Assert.Equal("matheus@email.com", memoryUserEmail);
        Assert.Equal("Matheus Macedo Santos", memoryAdministratorName);
    }
}

public class MemoryUsersRepository : IUsersRepository
{
    private List<User> Users = new List<User>();
    private List<AdministratorUser> AdministratorUsers = new List<AdministratorUser>();

    public Task CreateAdministratorUser(AdministratorUser administrator)
    {
        AdministratorUsers.Add(administrator);
        return Task.CompletedTask;
    }

    public Task CreateUser(User user)
    {
        Users.Add(user);
        return Task.CompletedTask;
    }

    public async Task DeleteAdministrator(Guid administratorId)
    {
        var administrator = await GetAdministratorById(administratorId);
        AdministratorUsers.Remove(administrator);
    }

    public async Task DeleteUser(Guid userId)
    {
        var user = await GetUserById(userId);
        Users.Remove(user);
    }

    public Task<AdministratorUser> GetAdministratorById(Guid administratorId)
    {
        foreach (AdministratorUser administrator in AdministratorUsers)
        {
            if (administrator.AdministratorId == administratorId)
                return Task.Factory.StartNew(() => administrator);
        }

        throw new Exception("Administrator not found.");
    }

    public Task<User> GetUserById(Guid userId)
    {
        foreach (User user in Users)
        {
            if (user.UserId == userId)
                return Task.Factory.StartNew(() => user);
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
