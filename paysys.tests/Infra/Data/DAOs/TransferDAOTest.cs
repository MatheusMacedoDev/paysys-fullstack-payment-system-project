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

    protected TransferDAOTest(DatabaseFixture databaseFixture) : base(databaseFixture)
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

        _transfersService = new TransfersService(
            userTypeNamesSettingsOptions,
            _transferStatusRepository,
            _transfersCategoriesRepository,
            _transfersRepository,
            _usersRepository,
            _userTypesRepositories,
            _commonUserDAO,
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

        _transferDAO = new TransferDAO(LocalConnetionString!);
    }

    [Fact]
    public async Task GetCommonUserTransactionHistoryTest()
    {
        var transactionCategoryName = "Alimentação";
        var transactionDescription = "Alguma descrição";
        var transactionValue = 300;

        var senderUserId = await StartInitialDatabaseData();

        var outputedTransfers = _transferDAO.GetCommonUserTransactionHistory(senderUserId);

        Assert.True(false);
    }

    private async Task<Guid> StartInitialDatabaseData()
    {
        var transferStatus = TransferStatus.Create("Realizado");
        await _transferStatusRepository.CreateTransferStatus(transferStatus);

        var transferCategory = TransferCategory.Create("Alimentos");
        await _transfersCategoriesRepository.CreateTransferCategory(transferCategory);

        var commonType = UserType.Create("Comum");
        await _userTypesRepositories.CreateUserType(commonType);
        await DbContext.SaveChangesAsync();

        var createSenderRequest = new CreateCommonUserRequest(
            commonUserName: "Matheus Macedo Santos",
            cpf: "58883749578",
            userName: "Math8006",
            email: "matheus@email.com",
            phoneNumber: "11947346577",
            password: "12345",
            userTypeId: commonType.UserTypeId
        );

        var createSenderResponse = await _usersService.CreateCommonUser(createSenderRequest);
        var senderUserId = createSenderResponse.userId;

        var increaseSenderBalanceRequest = new IncreaseCommonUserBalanceRequest(
            commonUserId: createSenderResponse.commonUserId,
            increaseAmount: 300
        );

        await _usersService.IncreaseCommonUserBalance(increaseSenderBalanceRequest);

        var createReceiverRequest = new CreateCommonUserRequest(
            commonUserName: "Lucas Santos Machado",
            cpf: "38843546598",
            userName: "Machadão",
            email: "lucas.machado@email.com",
            phoneNumber: "11947346577",
            password: "12345",
            userTypeId: commonType.UserTypeId
        );

        var createReceiverResponse = await _usersService.CreateCommonUser(createSenderRequest);
        var receiverUserId = createReceiverResponse.userId;

        var request = new CreateTransferRequest(
            transferDescription: "Some description",
            transferAmount: 300,
            transferStatus.TransferStatusId,
            transferCategory.TransferCategoryId,
            senderUserId,
            receiverUserId
        );

        var response = await _transfersService.CreateTransfer(request);

        return senderUserId;
    }
}