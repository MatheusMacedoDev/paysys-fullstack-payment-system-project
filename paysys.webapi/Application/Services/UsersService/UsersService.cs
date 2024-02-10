using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.UsersService;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepositories;
    private readonly IUnityOfWork _unityOfWork;

    private readonly ICryptographyStrategy _cryptographyStrategy;

    public UsersService(IUsersRepository usersRepository, IUnityOfWork unityOfWork, ICryptographyStrategy cryptographyStrategy)
    {
        _usersRepositories = usersRepository;
        _unityOfWork = unityOfWork;

        _cryptographyStrategy = cryptographyStrategy;
    }

    public async Task<CreateAdministratorResponse> CreateAdministrator(CreateAdministratorRequest request)
    {
        try
        {
            var salt = _cryptographyStrategy.MakeSalt();
            var hash = _cryptographyStrategy.MakeHashedPassword(request.password, salt);

            var user = User.Create(
                request.userName,
                request.email,
                request.phoneNumber,
                hash,
                salt,
                request.userTypeId
            );

            var administrator = AdministratorUser.Create(
                request.administratorName,
                request.cpf,
                user.UserId
            );

            await _usersRepositories.CreateUser(user);
            await _usersRepositories.CreateAdministratorUser(administrator);

            await _unityOfWork.Commit();

            var response = new CreateAdministratorResponse(
                administrator.AdministratorId,
                user.UserId,
                administrator.AdministratorName!
            );

            return response;
        }
        catch (Exception error)
        {
            System.Console.WriteLine(error);
            throw;
        }
    }
}
