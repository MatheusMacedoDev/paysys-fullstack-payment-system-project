using Microsoft.Extensions.Options;
using paysys.tests.Infra.Data.Database;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Services.TransfersService;
using paysys.webapi.Application.Services.UsersService;
using paysys.webapi.Application.Strategies.Cryptography;
using paysys.webapi.Application.Strategies.Token;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Infra.Data.DAOs.Implementation;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.Repositories;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.tests.Infra.Data.DAOs;

[Collection("Database")]
public class TransferDAOTest : DatabaseTestCase
{
    private readonly ITransfersService _transfersService;
    private readonly IUsersService _usersService;

    private readonly ITransferStatusRepository _transferStatusRepository;
    private readonly ITransferCategoriesRepository _transfersCategoriesRepository;
    private readonly ITransfersRepository _transfersRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IUserTypesRepository _userTypesRepositories;

    private readonly ICommonUserDAO _commonUserDAO;
    private readonly IShopkeeperDAO _shopkeeperDAO;
    private readonly ITransferDAO _transferDAO;

    public TransferDAOTest(DatabaseFixture databaseFixture) : base(databaseFixture)
    {
        var userTypeNamesSettings = new UserTypeNamesSettings
        {
            AdministratorTypeName = "Administrador",
            CommonTypeName = "Comum",
            ShopkeeperTypeName = "Lojista"
        };

        IOptions<UserTypeNamesSettings> userTypeNamesSettingsOptions = Options.Create(userTypeNamesSettings);

        _transferStatusRepository = new TransferStatusRepository(DbContext);
        _transfersCategoriesRepository = new TransferCategoriesRepository(DbContext);
        _transfersRepository = new TransfersRepository(DbContext);
        _usersRepository = new UsersRepository(DbContext);
        _userTypesRepositories = new UserTypesRepository(DbContext);

        _commonUserDAO = new CommonUserDAO(LocalConnetionString!);
        _shopkeeperDAO = new ShopkeeperDAO(LocalConnetionString!);
        _transferDAO = new TransferDAO(LocalConnetionString!);

        _transfersService = new TransfersService(
            userTypeNamesSettingsOptions,
            _transferStatusRepository,
            _transfersCategoriesRepository,
            _transfersRepository,
            _usersRepository,
            _userTypesRepositories,
            _commonUserDAO,
            _transferDAO,
            new UnityOfWork(DbContext)
        );

        var tokenSettings = new TokenSettings()
        {
            SecurityKey = "my_security_key_is_here_for_me_1234544",
            HoursToExpiration = 2
        };

        IOptions<TokenSettings> tokenSettingsOptions = Options.Create(tokenSettings);

        _usersService = new UsersService(
            _usersRepository,
            new UnityOfWork(DbContext),
            new CryptographyStrategy(),
            _commonUserDAO,
            _shopkeeperDAO,
            new AdministratorDAO(LocalConnetionString!),
            new TokenStrategy(tokenSettingsOptions),
            new UserDAO(LocalConnetionString!)
        );

    }

    [Fact]
    public async Task GetCommonUserTransactionHistoryBySenderUserTest()
    {
        var commonUserTypeId = await CreateCommonUserType();

        var createReceiverRequest = new CreateCommonUserRequest(
            commonUserName: "Lucas Santos Machado",
            cpf: "38843546598",
            userName: "Machadão",
            email: "lucas.machado@email.com",
            phoneNumber: "11947346577",
            password: "12345",
            userTypeId: commonUserTypeId
        );

        var createReceiverResponse = await _usersService.CreateCommonUser(createReceiverRequest);

        var transferData = await StartInitialDatabaseData(createReceiverResponse.userId, commonUserTypeId);

        var outputedTransfers = await _transferDAO.GetUserTransferHistory(transferData.userId);

        bool allTransfersAreFromSenderUser = false;

        foreach (var transfer in outputedTransfers)
        {
            if (transfer.isSenderTransferUser)
            {
                allTransfersAreFromSenderUser = true;
            }
            else
            {
                allTransfersAreFromSenderUser = false;
                break;
            }
        }

        Assert.True(allTransfersAreFromSenderUser);
    }

    [Fact]
    public async Task GetShopkeeperTransactionHistoryUserTest()
    {
        var commonUserTypeId = await CreateCommonUserType();
        var shopkeeperUserTypeId = await CreateShopkeeperUserType();

        var createReceiverRequest = new CreateShopkeeperRequest(
            fancyName: "Machado Store",
            companyName: "Machado LTDA",
            userName: "Machadão",
            cnpj: "16382209000105",
            email: "lucas.machado@email.com",
            phoneNumber: "11947346577",
            password: "12345",
            userTypeId: shopkeeperUserTypeId
        );

        var createReceiverResponse = await _usersService.CreateShopkeeper(createReceiverRequest);

        await StartInitialDatabaseData(createReceiverResponse.userId, commonUserTypeId);

        var outputedTransfers = await _transferDAO.GetUserTransferHistory(createReceiverResponse.userId);

        bool allTransfersAreFromReceiverUser = false;

        foreach (var transfer in outputedTransfers)
        {
            if (!transfer.isSenderTransferUser)
            {
                allTransfersAreFromReceiverUser = true;
            }
            else
            {
                allTransfersAreFromReceiverUser = false;
                break;
            }
        }

        Assert.True(allTransfersAreFromReceiverUser);

        Assert.True(true);
    }

    [Fact]
    public async Task GetFullTransactionTest()
    {
        var commonUserTypeId = await CreateCommonUserType();

        var createReceiverRequest = new CreateCommonUserRequest(
            commonUserName: "Lucas Santos Machado",
            cpf: "38843546598",
            userName: "Machadão",
            email: "lucas.machado@email.com",
            phoneNumber: "11947346577",
            password: "12345",
            userTypeId: commonUserTypeId
        );

        var createReceiverResponse = await _usersService.CreateCommonUser(createReceiverRequest);

        var transferData = await StartInitialDatabaseData(createReceiverResponse.userId, commonUserTypeId);

        var outputedTransfer = await _transferDAO.GetFullTransfer(transferData.transferId, transferData.userId);

        Assert.True(true);
    }

    private async Task<Guid> CreateCommonUserType()
    {
        var commonType = new UserType("Comum");
        await _userTypesRepositories.CreateUserType(commonType);
        await DbContext.SaveChangesAsync();

        return commonType.UserTypeId;
    }

    private async Task<Guid> CreateShopkeeperUserType()
    {
        var commonType = new UserType("Lojista");
        await _userTypesRepositories.CreateUserType(commonType);
        await DbContext.SaveChangesAsync();

        return commonType.UserTypeId;
    }

    private async Task<TransferLocalData> StartInitialDatabaseData(Guid receiverUserId, Guid commonUserTypeId)
    {
        var transferStatus = TransferStatus.Create("Realizado");
        await _transferStatusRepository.CreateTransferStatus(transferStatus);

        var transferCategory = TransferCategory.Create("Alimentos");
        await _transfersCategoriesRepository.CreateTransferCategory(transferCategory);

        var createSenderRequest = new CreateCommonUserRequest(
            commonUserName: "Matheus Macedo Santos",
            cpf: "58883749578",
            userName: "Math8006",
            email: "matheus@email.com",
            phoneNumber: "11947346577",
            password: "12345",
            userTypeId: commonUserTypeId
        );

        var createSenderResponse = await _usersService.CreateCommonUser(createSenderRequest);
        var senderUserId = createSenderResponse.userId;

        var increaseSenderBalanceRequest = new IncreaseCommonUserBalanceRequest(
            commonUserId: createSenderResponse.commonUserId,
            increaseAmount: 300
        );

        await _usersService.IncreaseCommonUserBalance(increaseSenderBalanceRequest);

        var request = new CreateTransferRequest(
            transferDescription: "Some description",
            transferAmount: 300,
            transferStatus.TransferStatusId,
            transferCategory.TransferCategoryId,
            senderUserId,
            receiverUserId
        );

        var response = await _transfersService.CreateTransfer(request);

        return new TransferLocalData(response.transferId, senderUserId);
    }
}

public record TransferLocalData(Guid transferId, Guid userId);
