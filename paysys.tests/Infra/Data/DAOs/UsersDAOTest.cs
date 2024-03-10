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
            Assert.Fail("User not found.");

        Assert.Equal(expectedUserName, outputedUser.userName);
    }

    [Fact]
    public async Task GetUsersByNameOrUsername()
    {
        var name = "Matheus";

        await StartInitialDatabaseData();
        var outputedUsers = await _userDAO.GetUsersByNameOrUsername(name);

        if (outputedUsers == null)
            Assert.Fail("There is no users list.");

        if (!outputedUsers.Any())
            Assert.Fail("No users founded.");

        var searchWorked = true;
        name = name.ToLower();

        foreach (var user in outputedUsers)
        {
            if (!user.userName.ToLower().Contains(name)
                && !user.commonUserName.ToLower().Contains(name)
                && !user.shopkeeperFancyName.ToLower().Contains(name)
                || user.userTypeName.ToLower() == "lojista")
            {
                searchWorked = false;
            }
        }

        Assert.True(searchWorked);
    }

    private async Task StartInitialDatabaseData()
    {
        var commonUserType = UserType.Create("Comum");
        var shopkeeperUserType = UserType.Create("Lojista");
        var administratorUserType = UserType.Create("Administrador");

        var userTypesRepository = new UserTypesRepository(DbContext);

        await userTypesRepository.CreateUserType(commonUserType);
        await userTypesRepository.CreateUserType(shopkeeperUserType);
        await userTypesRepository.CreateUserType(administratorUserType);

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


        var createAdministratorRequest = new CreateAdministratorRequest(
            administratorName: "Matheus da Rocha",
            cpf: "52228475764",
            userName: "MaHahaha",
            email: "rocha@email.com",
            phoneNumber: "11947365477",
            password: "12345",
            userTypeId: administratorUserType.UserTypeId
        );

        await usersService.CreateAdministrator(createAdministratorRequest);
    }
}
