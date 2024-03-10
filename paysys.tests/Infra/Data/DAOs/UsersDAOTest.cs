using paysys.tests.Infra.Data.Database;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Infra.Data.DAOs.Implementation;
using paysys.webapi.Infra.Data.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.tests.Infra.Data.DAOs;

[Collection("Database")]
public class UsersDAOTest : DatabaseTestCase
{
    private readonly IUsersDAO _usersDAO;

    protected UsersDAOTest(DatabaseFixture databaseFixture) : base(databaseFixture)
    {
        _usersDAO = new UsersDAO();
    }

    [Fact]
    public async Task GetUserByEmail()
    {
        var email = "matheus@email.com";
        var expectedUserName = "Math8006";
        var expectedPhoneNumber = "11947346577";

        await StartInitialDatabaseData();
        var outputedUser = await _usersDAO.GetUserByEmail(email);

        Assert.Equal(expectedUserName, outputedUser.userName);
        Assert.Equal(expectedPhoneNumber, outputedUser.phoneNumber);
    }

    private async Task StartInitialDatabaseData()
    {
        var commonUserType = UserType.Create("Comum");

        var usersService = new UsersService(
            new UsersRepository(DbContext),
            new UnityOfWork(DbContext),
            new CryptographyStrategy(),
            new CommonUserDAO(),
            new ShopkeeperDAO(),
            new AdministratorDAO()
        );

        var createCommonUserRequest = new CreateCommonUserRequest(
            commonUserName: "Matheus Macedo Santos",
            cpf: "58883749578",
            userName: "Math8006",
            email: "matheus@email.com",
            phoneNumber: "11947346577",
            password: "12345",
            userTypeId: commonUserType.UserTypeId
        );

        await usersService.CreateCommonUser(createCommonUserRequest);
    }
}
