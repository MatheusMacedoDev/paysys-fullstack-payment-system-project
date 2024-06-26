﻿using Microsoft.Extensions.Options;
using paysys.tests.Infra.Data.Database;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Application.Strategies.Token;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Infra.Data.DAOs.Implementation;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;
using paysys.webapi.Infra.Mail.Service;

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
        var expectedUserTypeName = "Comum";

        await StartInitialDatabaseData();
        var outputedUser = await _userDAO.GetUserByEmail(email);

        if (outputedUser == null)
            Assert.Fail("User not found.");

        Assert.Equal(expectedUserName, outputedUser.userName);
        Assert.Equal(expectedUserTypeName, outputedUser.userTypeName);
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
        var commonUserType = new UserType("Comum");
        var shopkeeperUserType = new UserType("Lojista");
        var administratorUserType = new UserType("Administrador");

        var userTypesRepository = new UserTypesRepository(DbContext);

        await userTypesRepository.CreateUserType(commonUserType);
        await userTypesRepository.CreateUserType(shopkeeperUserType);
        await userTypesRepository.CreateUserType(administratorUserType);

        await DbContext.SaveChangesAsync();

        var tokenSettings = new TokenSettings()
        {
            SecurityKey = "my_security_key_is_here_for_me_1234544",
            HoursToExpiration = 2
        };

        IOptions<TokenSettings> tokenSettingsOptions = Options.Create(tokenSettings);

        var smtpSettings = new SmtpSettings()
        {
            SmtpServer = "smtp.ethereal.email",
            Port = 587,
            SenderName = "Kyle Stark",
            SenderEmail = "kyle.stark86@ethereal.email",
            SenderPassword = "WFQnaA8GPwGBPmY1pm"

        };

        IOptions<SmtpSettings> smtpSettingsOptions = Options.Create(smtpSettings);

        IMailInfraService mailInfraService = new MailInfraService(smtpSettingsOptions, disableService: true);

        var usersService = new UsersService(
            new UsersRepository(DbContext),
            new UnityOfWork(DbContext),
            new CryptographyStrategy(),
            new CommonUserDAO(LocalConnetionString!),
            new ShopkeeperDAO(LocalConnetionString!),
            new AdministratorDAO(LocalConnetionString!),
            new TokenStrategy(tokenSettingsOptions),
            new UserDAO(LocalConnetionString!),
            mailInfraService
        );

        var createCommonUserRequest = new CreateCommonUserRequest(
            commonUserName: "Matheus Macedo Santos",
            cpf: "58883749578",
            userName: "Math8006",
            email: "matheus@email.com",
            phoneNumber: "11947346577",
            password: "Matheus@8006",
            userTypeId: commonUserType.UserTypeId
        );

        await usersService.CreateCommonUser(createCommonUserRequest);


        var createAdministratorRequest = new CreateAdministratorRequest(
            administratorName: "Matheus da Rocha",
            cpf: "52228475764",
            userName: "MaHahaha",
            email: "rocha@email.com",
            phoneNumber: "11947365477",
            password: "Matheus@8006",
            userTypeId: administratorUserType.UserTypeId
        );

        await usersService.CreateAdministrator(createAdministratorRequest);
    }
}
