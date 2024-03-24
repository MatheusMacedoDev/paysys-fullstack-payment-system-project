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

namespace paysys.tests.Application.Services;

[Collection("Database")]
public class TransferServiceTest : DatabaseTestCase
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

    public TransferServiceTest(DatabaseFixture databaseFixture) : base(databaseFixture)
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
            new TransferDAO(LocalConnetionString!),
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
    public async Task CreateTransferCommonToCommonTest()
    {
        // Arrange
        double initialSenderUserDeposit = 700;
        double transferAmount = 500;
        double expectedSenderUserFinalBalance = 200;
        double expectedReceiverUserFinalBalance = 500;

        Guid transferStatusId;
        Guid transferCategoryId;
        Guid senderUserId;
        Guid receiverUserId;

        var transferStatus = TransferStatus.Create("Realizado");
        transferStatusId = transferStatus.TransferStatusId;
        await _transferStatusRepository.CreateTransferStatus(transferStatus);

        var transferCategory = TransferCategory.Create("Alimentos");
        transferCategoryId = transferCategory.TransferCategoryId;
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
        senderUserId = createSenderResponse.userId;

        var increaseSenderBalanceRequest = new IncreaseCommonUserBalanceRequest(
            commonUserId: createSenderResponse.commonUserId,
            increaseAmount: initialSenderUserDeposit
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
        receiverUserId = createReceiverResponse.userId;

        var request = new CreateTransferRequest(
            transferDescription: "Some description",
            transferAmount,
            transferStatusId,
            transferCategoryId,
            senderUserId,
            receiverUserId
        );

        // Act
        var response = await _transfersService.CreateTransfer(request);

        double currentSenderUserFinalBalance = await _commonUserDAO.GetCommonUserBalanceByUserId(senderUserId);
        double currentReceiverUserFinalBalance = await _commonUserDAO.GetCommonUserBalanceByUserId(receiverUserId);

        // Assert
        Assert.Equal(expectedReceiverUserFinalBalance, currentReceiverUserFinalBalance);
        Assert.Equal(expectedSenderUserFinalBalance, currentSenderUserFinalBalance);
    }

    [Fact]
    public async Task CreateTransferCommonToShopkeeperTest()
    {
        // Arrange
        double initialSenderUserDeposit = 600;
        double transferAmount = 550;
        double expectedSenderUserFinalBalance = 50;
        double expectedReceiverUserFinalBalance = 550;

        Guid transferStatusId;
        Guid transferCategoryId;
        Guid senderUserId;
        Guid receiverUserId;

        var transferStatus = TransferStatus.Create("Realizado");
        transferStatusId = transferStatus.TransferStatusId;
        await _transferStatusRepository.CreateTransferStatus(transferStatus);

        var transferCategory = TransferCategory.Create("Alimentos");
        transferCategoryId = transferCategory.TransferCategoryId;
        await _transfersCategoriesRepository.CreateTransferCategory(transferCategory);

        var commonType = UserType.Create("Comum");
        var shopkeeperType = UserType.Create("Lojista");

        await _userTypesRepositories.CreateUserType(commonType);
        await _userTypesRepositories.CreateUserType(shopkeeperType);

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
        senderUserId = createSenderResponse.userId;

        var increaseSenderBalanceRequest = new IncreaseCommonUserBalanceRequest(
            commonUserId: createSenderResponse.commonUserId,
            increaseAmount: initialSenderUserDeposit
        );

        await _usersService.IncreaseCommonUserBalance(increaseSenderBalanceRequest);

        var createReceiverRequest = new CreateShopkeeperRequest(
            fancyName: "Uber",
            companyName: "Uber LTDA",
            cnpj: "00895351000108",
            userName: "uberUser",
            email: "transfer@uber.com",
            phoneNumber: "11958475877",
            password: "12345",
            userTypeId: shopkeeperType.UserTypeId
        );

        var createReceiverResponse = await _usersService.CreateShopkeeper(createReceiverRequest);
        receiverUserId = createReceiverResponse.userId;

        var request = new CreateTransferRequest(
            transferDescription: "Some description",
            transferAmount,
            transferStatusId,
            transferCategoryId,
            senderUserId,
            receiverUserId
        );

        // Act
        var response = await _transfersService.CreateTransfer(request);

        double currentSenderUserFinalBalance = await _commonUserDAO.GetCommonUserBalanceByUserId(senderUserId);
        double currentReceiverUserFinalBalance = await _shopkeeperDAO.GetShopkeeperBalanceByUserId(receiverUserId);

        // Assert
        Assert.Equal(expectedReceiverUserFinalBalance, currentReceiverUserFinalBalance);
        Assert.Equal(expectedSenderUserFinalBalance, currentSenderUserFinalBalance);
    }
}
