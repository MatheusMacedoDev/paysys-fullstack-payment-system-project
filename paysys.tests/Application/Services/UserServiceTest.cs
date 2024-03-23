using Microsoft.Extensions.Options;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Application.Strategies.Token;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.DAOs.Implementation;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
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
        ICommonUserDAO commonUserDAO = new CommonUserDAO();
        IShopkeeperDAO shopkeeperDAO = new ShopkeeperDAO();
        IAdministratorDAO administratorDAO = new AdministratorDAO("");

        var tokenSettings = new TokenSettings()
        {
            SecurityKey = "my_security_key_is_here_for_me_1234544",
            HoursToExpiration = 2
        };

        IOptions<TokenSettings> tokenSettingsOptions = Options.Create(tokenSettings);
        ITokenStrategy tokenStrategy = new TokenStrategy(tokenSettingsOptions);

        IUserDAO userDAO = new UserDAO();

        _usersService = new UsersService(_usersRepository, unityOfWork, cryptographyStrategy, commonUserDAO, shopkeeperDAO, administratorDAO, tokenStrategy, userDAO);
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

    [Fact]
    public async Task CreateCommonUser()
    {
        var request = new CreateCommonUserRequest(
            "Lucas Santos",
            "53342849834",
            "Machado342",
            "lucas@email.com",
            "974735847",
            "12345",
            Guid.NewGuid()
        );

        var response = await _usersService.CreateCommonUser(request);

        var memoryUserEmail = (await _usersRepository.GetUserById(response.userId)).Email;
        var memoryCommonUserName = (await _usersRepository.GetCommonUserById(response.commonUserId)).CommonUserName;

        Assert.Equal("lucas@email.com", memoryUserEmail);
        Assert.Equal("Lucas Santos", memoryCommonUserName);
    }

    [Fact]
    public async Task CreateShopkeeper()
    {
        var request = new CreateShopkeeperRequest(
            "Amazon",
            "Amazon LTDA",
            "15436940000103",
            "AmazonBR1",
            "store@amazon.com",
            "11943827463",
            "12345",
            Guid.NewGuid()
        );

        var response = await _usersService.CreateShopkeeper(request);

        var memoryUserEmail = (await _usersRepository.GetUserById(response.userId)).Email;
        var memoryShopkeeperFancyName = (await _usersRepository.GetShopkeeperById(response.shopkeeperId)).FancyName;

        Assert.Equal("store@amazon.com", memoryUserEmail);
        Assert.Equal("Amazon", memoryShopkeeperFancyName);
    }
}

public class MemoryUsersRepository : IUsersRepository
{
    private List<User> Users = new List<User>();
    private List<AdministratorUser> AdministratorUsers = new List<AdministratorUser>();
    private List<CommonUser> CommonUsers = new List<CommonUser>();
    private List<Shopkeeper> Shopkeepers = new List<Shopkeeper>();

    public Task<double> ChangeCommonUserBalance(Guid commonUserId, double newBalance)
    {
        throw new NotImplementedException();
    }

    public Task CreateAdministratorUser(AdministratorUser administrator)
    {
        AdministratorUsers.Add(administrator);
        return Task.CompletedTask;
    }

    public Task CreateCommonUser(CommonUser commonUser)
    {
        CommonUsers.Add(commonUser);
        return Task.CompletedTask;
    }

    public Task CreateShopkeeper(Shopkeeper shopkeeper)
    {
        Shopkeepers.Add(shopkeeper);
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

    public Task<CommonUser> GetCommonUserById(Guid commonUserId)
    {
        foreach (CommonUser commonUser in CommonUsers)
        {
            if (commonUser.CommonUserId == commonUserId)
                return Task.Factory.StartNew(() => commonUser);
        }

        throw new Exception("Common User not found.");
    }

    public Task<CommonUser> GetCommonUserByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Shopkeeper> GetShopkeeperById(Guid shopkeeperId)
    {
        foreach (Shopkeeper shopkeeper in Shopkeepers)
        {
            if (shopkeeper.ShopkeeperId == shopkeeperId)
                return Task.Factory.StartNew(() => shopkeeper);
        }

        throw new Exception("Shopkeeper not found.");
    }

    public Task<Shopkeeper> GetShopkeeperByUserId(Guid userId)
    {
        throw new NotImplementedException();
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
