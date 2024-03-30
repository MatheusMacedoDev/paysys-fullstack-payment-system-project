using Microsoft.Extensions.Options;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Domain.Specifications;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.UnityOfWork;

namespace paysys.webapi.Application.Services.TransfersService;

public class TransfersService : ITransfersService
{
    // Configuration
    private readonly IOptions<UserTypeNamesSettings> _userTypeNamesSettings;

    // Repositories
    private readonly ITransferStatusRepository _transferStatusRepository;
    private readonly ITransferCategoriesRepository _transferCategoriesRepository;
    private readonly ITransfersRepository _transfersRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IUserTypesRepository _userTypesRepository;

    // DAOs
    private readonly ICommonUserDAO _commonUserDAO;
    private readonly ITransferDAO _transferDAO;

    // Unity of Work
    private readonly IUnityOfWork _unityOfWork;

    public TransfersService(IOptions<UserTypeNamesSettings> userTypeNamesSettings, ITransferStatusRepository transferStatusRepository, ITransferCategoriesRepository transferCategoriesRepository, ITransfersRepository transfersRepository, IUsersRepository usersRepository, IUserTypesRepository userTypesRepository, ICommonUserDAO commonUserDAO, ITransferDAO transferDAO, IUnityOfWork unityOfWork)
    {
        _userTypeNamesSettings = userTypeNamesSettings;

        _transferStatusRepository = transferStatusRepository;
        _transferCategoriesRepository = transferCategoriesRepository;
        _transfersRepository = transfersRepository;
        _usersRepository = usersRepository;
        _userTypesRepository = userTypesRepository;

        _commonUserDAO = commonUserDAO;
        _transferDAO = transferDAO;

        _unityOfWork = unityOfWork;
    }

    public CreateTransferCategoryResponse CreateTransferCategory(CreateTransferCategoryRequest request)
    {
        try
        {
            var transferCategory = new TransferCategory(
                request.transferCategoryName
            );

            _transferCategoriesRepository.CreateTransferCategory(transferCategory);
            _unityOfWork.Commit();

            var response = new CreateTransferCategoryResponse(
                transferCategory.TransferCategoryId,
                transferCategory.TransferCategoryName!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GetAllTransferCategoriesResponse> GetAllTransferCategories()
    {
        try
        {
            var transferCategoriesList = await _transferCategoriesRepository.GetAllTransferCategories();
            var response = new GetAllTransferCategoriesResponse(transferCategoriesList);

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public CreateTransferStatusResponse CreateTransferStatus(CreateTransferStatusRequest request)
    {
        try
        {
            var transferStatus = new TransferStatus(
                request.transferStatusName
            );

            _transferStatusRepository.CreateTransferStatus(transferStatus);
            _unityOfWork.Commit();

            var response = new CreateTransferStatusResponse(
                transferStatus.TransferStatusId,
                transferStatus.TransferStatusName!
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GetAllTransferStatusResponse> GetAllTransferStatus()
    {
        try
        {
            var transferStatusList = await _transferStatusRepository.GetAllTransferStatus();
            var response = new GetAllTransferStatusResponse(transferStatusList);

            return response;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<CreateTransferResponse> CreateTransfer(CreateTransferRequest request)
    {
        try
        {
            var transfer = Transfer.Create(
                transferDescription: request.transferDescription,
                transferAmount: request.transferAmount,
                transferStatusId: request.transferStatusId,
                transferCategoryId: request.transferCategoryId,
                senderUserId: request.senderUserId,
                receiverUserId: request.receiverUserId
            );

            var senderUser = await _usersRepository.GetUserById(transfer.SenderUserId);
            var senderUserType = await _userTypesRepository.GetUserType(senderUser.UserTypeId)!;

            var receiverUser = await _usersRepository.GetUserById(transfer.ReceiverUserId);
            var receiverUserType = await _userTypesRepository.GetUserType(receiverUser.UserTypeId)!;

            var isAdministratorSpecification = new IsAdministratorUserSpecification(
                _userTypeNamesSettings
            );

            await MakeSenderUserValidations(isAdministratorSpecification, senderUserType, transfer.SenderUserId, transfer);
            MakeReceiverUserValidations(isAdministratorSpecification, receiverUserType);

            await _transfersRepository.CreateTransfer(transfer);

            await DecreaseSenderUserBalance(senderUser, transfer.TransferAmount);
            await IncreaseReceiverUserBalance(receiverUser, receiverUserType, transfer.TransferAmount);

            await _unityOfWork.Commit();

            var response = new CreateTransferResponse(
                transferId: transfer.TransferId,
                transferDescription: transfer.TransferDescription!,
                transferAmount: transfer.TransferAmount,
                transferDateTime: transfer.TransferDateTime,
                transferStatusId: transfer.TransferStatusId,
                transferCategoryId: transfer.TransferCategoryId,
                senderUserId: transfer.SenderUserId,
                receiverUserId: transfer.ReceiverUserId
            );

            return response;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<GetUserTransferHistoryResponse> GetUserTransferHistory(GetUserTransferHistoryRequest request)
    {
        var transferHistory = await _transferDAO.GetUserTransferHistory(request.userId);
        var response = new GetUserTransferHistoryResponse(transferHistory);

        return response;
    }

    public async Task<GetFullTransferResponse> GetFullTransfer(GetFullTransferRequest request)
    {
        var fullTransfer = await _transferDAO.GetFullTransfer(request.transferId, request.userId);
        var response = new GetFullTransferResponse(fullTransfer);

        return response;
    }

    private async Task MakeSenderUserValidations(IsAdministratorUserSpecification isAdministratorSpecification, UserType senderUserType, Guid senderUserId, Transfer transfer)
    {
        // Sender is not administrator validation

        var senderIsAdministrator = isAdministratorSpecification.IsSatisfiedBy(senderUserType);

        if (senderIsAdministrator)
        {
            throw new ArgumentException("The administrator is not allowed to send a transfer.");
        }

        // Sender is not shopkeeper validation

        var isShopkeeperSpecification = new IsShopkeeperSpecification(
            _userTypeNamesSettings
        );

        var senderIsShopkeeper = isShopkeeperSpecification.IsSatisfiedBy(senderUserType);

        if (senderIsShopkeeper)
        {
            throw new ArgumentException("The shopkeeper is not allowed to send a transfer.");
        }

        // Sender have enough money to make transfer

        var haveEnoughMoneySpecification = new HaveEnoughMoneySpecification(
            _userTypeNamesSettings,
            senderUserId,
            senderUserType.TypeName!,
            _commonUserDAO
        );

        var senderHaveNotEnoughMoney = !(await haveEnoughMoneySpecification.IsSatisfiedBy(transfer));

        if (senderHaveNotEnoughMoney)
        {
            throw new ArgumentException("The sender have not enough money to make this transfer.");
        }
    }

    private void MakeReceiverUserValidations(IsAdministratorUserSpecification isAdministratorSpecification, UserType receiverUserType)
    {
        var receiverIsAdministrator = isAdministratorSpecification.IsSatisfiedBy(receiverUserType);

        if (receiverIsAdministrator)
        {
            throw new ArgumentException("The administrator is not allowed to receive a transfer");
        }
    }

    private async Task DecreaseSenderUserBalance(User senderUser, double decreaseAmount)
    {
        CommonUser common = await _usersRepository.GetCommonUserByUserId(senderUser.UserId);
        common.DecreaseMoney(decreaseAmount);
    }

    private async Task IncreaseReceiverUserBalance(User receiverUser, UserType receiverUserType, double increaseAmount)
    {
        if (receiverUserType.TypeName == _userTypeNamesSettings.Value.CommonTypeName)
        {
            CommonUser common = await _usersRepository.GetCommonUserByUserId(receiverUser.UserId);
            common.IncreaseMoney(increaseAmount);
        }
        else if (receiverUserType.TypeName == _userTypeNamesSettings.Value.ShopkeeperTypeName)
        {
            Shopkeeper shopkeeper = await _usersRepository.GetShopkeeperByUserId(receiverUser.UserId);
            shopkeeper.IncreaseMoney(increaseAmount);
        }
        else
        {
            throw new ArgumentException("You can increase balance only for common and shopkeeper users.");
        }
    }

}
