using paysys.tests.Infra.Data.Database;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Infra.Data.DAOs.Implementation;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.tests.Infra.Data.DAOs;

[Collection("Database")]
public class UsersDAOTest : DatabaseTestCase
{
    private readonly IUserDAO _userDAO;

    public UsersDAOTest(DatabaseFixture databaseFixture) : base(databaseFixture)
    {
        _userDAO = new UserDAO(LocalConnetionString!);
    }

    [Fact]
    public async Task GetUserByEmail()
    {
        var email = "matheus@email.com";
        var expectedUserName = "Math8006";

        await StartInitialDatabaseData();
        var outputedUser = await _userDAO.GetUserByEmail(email);

        if (outputedUser == null)
        {
            Assert.Fail("User not found.");
        }

        Assert.Equal(expectedUserName, outputedUser.userName);
    }

    private async Task StartInitialDatabaseData()
    {
        var commonUserType = UserType.Create("Comum");

        var userTypesRepository = new UserTypesRepository(DbContext);

        await userTypesRepository.CreateUserType(commonUserType);
        await DbContext.SaveChangesAsync();

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
