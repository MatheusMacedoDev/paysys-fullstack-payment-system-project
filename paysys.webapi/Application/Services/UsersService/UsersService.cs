using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.UsersService;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepositories;
    private readonly IUnityOfWork _unityOfWork;

    private readonly ICommonUserDAO _commonUserDAO;

    private readonly ICryptographyStrategy _cryptographyStrategy;

    public UsersService(IUsersRepository usersRepository, IUnityOfWork unityOfWork, ICryptographyStrategy cryptographyStrategy, ICommonUserDAO commonUserDAO)
    {
        _usersRepositories = usersRepository;
        _unityOfWork = unityOfWork;

        _commonUserDAO = commonUserDAO;

        _cryptographyStrategy = cryptographyStrategy;
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

    public async Task<GetShortCommonUsersResponse> GetShortCommonUsers()
    {
        var commonUsersQuantity = 0;
        var shortCommonUsersList = await _commonUserDAO.getShortCommonUsers();

        var response = new GetShortCommonUsersResponse(commonUsersQuantity, shortCommonUsersList);

        return response;
    }

    private async Task<User> CreateUser(string userName, string email, string phoneNumber, string password, Guid userTypeId)
    {
        var salt = _cryptographyStrategy.MakeSalt();
        var hash = _cryptographyStrategy.MakeHashedPassword(password, salt);

        var user = User.Create(
            userName,
            email,
            phoneNumber,
            hash,
            salt,
            userTypeId
        );

        await _usersRepositories.CreateUser(user);

        return user;
    }
}
