using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Application.Strategies.Token;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.DAOs.TransferObjects;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.UsersService;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepositories;
    private readonly IUnityOfWork _unityOfWork;

    private readonly ICommonUserDAO _commonUserDAO;
    private readonly IShopkeeperDAO _shopkeeperDAO;
    private readonly IAdministratorDAO _administratorDAO;
    private readonly IUserDAO _userDAO;

    private readonly ICryptographyStrategy _cryptographyStrategy;
    private readonly ITokenStrategy _tokenStrategy;

    public UsersService(IUsersRepository usersRepository, IUnityOfWork unityOfWork, ICryptographyStrategy cryptographyStrategy, ICommonUserDAO commonUserDAO, IShopkeeperDAO shopkeeperDAO, IAdministratorDAO administratorDAO, ITokenStrategy tokenStrategy, IUserDAO userDAO)
    {
        _usersRepositories = usersRepository;
        _unityOfWork = unityOfWork;

        _commonUserDAO = commonUserDAO;
        _shopkeeperDAO = shopkeeperDAO;
        _administratorDAO = administratorDAO;
        _userDAO = userDAO;

        _cryptographyStrategy = cryptographyStrategy;
        _tokenStrategy = tokenStrategy;
    }

    public async Task<CreateAdministratorResponse> CreateAdministrator(CreateAdministratorRequest request)
    {
        try
        {
            var user = await CreateUser(
                request.userName,
                request.email,
                request.phoneNumber,
                request.password,
                request.userTypeId
            );

            var administrator = AdministratorUser.Create(
                request.administratorName,
                request.cpf,
                user.UserId
            );

            await _usersRepositories.CreateAdministratorUser(administrator);

            await _unityOfWork.Commit();

            var response = new CreateAdministratorResponse(
                administrator.AdministratorId,
                user.UserId,
                administrator.AdministratorName!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CreateCommonUserResponse> CreateCommonUser(CreateCommonUserRequest request)
    {
        try
        {
            var user = await CreateUser(
                request.userName,
                request.email,
                request.phoneNumber,
                request.password,
                request.userTypeId
            );

            var commonUser = CommonUser.Create(
                request.commonUserName,
                request.cpf,
                user.UserId
            );

            await _usersRepositories.CreateCommonUser(commonUser);

            await _unityOfWork.Commit();

            var response = new CreateCommonUserResponse(
                commonUser.CommonUserId,
                user.UserId,
                commonUser.CommonUserName!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CreateShopkeeperResponse> CreateShopkeeper(CreateShopkeeperRequest request)
    {
        try
        {
            var user = await CreateUser(
                request.userName,
                request.email,
                request.phoneNumber,
                request.password,
                request.userTypeId
            );

            var shopkeeper = Shopkeeper.Create(
                request.fancyName,
                request.companyName,
                request.cnpj,
                user.UserId
            );

            await _usersRepositories.CreateShopkeeper(shopkeeper);

            await _unityOfWork.Commit();

            var response = new CreateShopkeeperResponse(
                shopkeeper.ShopkeeperId,
                user.UserId,
                shopkeeper.FancyName!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GetFullAdministratorResponse> GetFullAdministrator(GetFullAdministratorRequest request)
    {
        var fullAdminstrator = await _administratorDAO.GetFullAdministratorById(request.administratorId);
        var response = new GetFullAdministratorResponse(fullAdminstrator);
        return response;
    }

    public async Task<GetFullCommonUserResponse> GetFullCommonUser(GetFullCommonUserRequest request)
    {
        var fullCommonUser = await _commonUserDAO.GetFullCommonUserById(request.commonUserId);
        var response = new GetFullCommonUserResponse(fullCommonUser);
        return response;
    }

    public async Task<GetFullShopkeeperResponse> GetFullShopkeeper(GetFullShopkeeperRequest request)
    {
        var fullShopkeeper = await _shopkeeperDAO.GetFullShopkeeperById(request.shopkeeperId);
        var response = new GetFullShopkeeperResponse(fullShopkeeper);
        return response;
    }

    public async Task<GetShortAdministratorsResponse> GetShortAdministrators()
    {
        var administratosQuantity = await _administratorDAO.GetAdministratorsQuantity();
        var shortAdministratorsList = await _administratorDAO.GetShortAdministrators();

        var response = new GetShortAdministratorsResponse(administratosQuantity, shortAdministratorsList);

        return response;
    }

    public async Task<GetShortCommonUsersResponse> GetShortCommonUsers()
    {
        var commonUsersQuantity = await _commonUserDAO.GetCommonUsersQuantity();
        var shortCommonUsersList = await _commonUserDAO.GetShortCommonUsers();

        var response = new GetShortCommonUsersResponse(commonUsersQuantity, shortCommonUsersList);

        return response;
    }

    public async Task<GetShortShopkeeperResponse> GetShortShopkeepers()
    {
        var shopkeepersQuantity = await _shopkeeperDAO.GetShopkeepersQuantity();
        var shortShopkeepersList = await _shopkeeperDAO.GetShortShopkeepers();

        var response = new GetShortShopkeeperResponse(shopkeepersQuantity, shortShopkeepersList);

        return response;
    }

    private async Task<User> CreateUser(string userName, string email, string phoneNumber, string password, Guid userTypeId)
    {
        var user = new User(
            userName,
            email,
            phoneNumber,
            password,
            userTypeId,
            _cryptographyStrategy
        );

        await _usersRepositories.CreateUser(user);

        return user;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        UserForLoginTO findedUser = await _userDAO.GetUserByEmail(request.userEmail);

        if (findedUser == null)
            throw new Exception("Dados inválidos.");

        var hashMatching = _cryptographyStrategy.VerifyHashedPassword(request.userPassword, findedUser.userHash, findedUser.userSalt);

        if (!hashMatching)
            throw new Exception("Dados inválidos.");

        var loginToken = _tokenStrategy.GenerateToken(findedUser);

        return new LoginResponse(loginToken);
    }

    public async Task<IncreaseCommonUserBalanceResponse> IncreaseCommonUserBalance(IncreaseCommonUserBalanceRequest request)
    {
        try
        {
            var newBalance = await _usersRepositories.ChangeCommonUserBalance(request.commonUserId, request.increaseAmount);
            await _unityOfWork.Commit();

            var response = new IncreaseCommonUserBalanceResponse(
                commonUserId: request.commonUserId,
                increasedAmount: request.increaseAmount,
                newBalance
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
