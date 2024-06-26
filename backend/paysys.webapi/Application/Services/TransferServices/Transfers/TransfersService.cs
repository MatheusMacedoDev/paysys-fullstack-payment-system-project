using Microsoft.Extensions.Options;
using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;
using paysys.webapi.Domain.Specifications;
using paysys.webapi.Infra.Data.DAOs.Interfaces;
using paysys.webapi.Infra.Data.UnityOfWork;
using paysys.webapi.Infra.Mail.Requests;
using paysys.webapi.Infra.Mail.Service;
using paysys.webapi.Infra.Mail.Templates;

namespace paysys.webapi.Application.Services.TransferServices.Transfers;

public class TransfersService : ITransfersService
{
    // Configuration
    private readonly IOptions<UserTypeNamesSettings> _userTypeNamesSettings;

    // Repositories
    private readonly ITransfersRepository _transfersRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IUserTypesRepository _userTypesRepository;

    // DAOs
    private readonly ICommonUserDAO _commonUserDAO;
    private readonly ITransferDAO _transferDAO;

    // Unity of Work
    private readonly IUnityOfWork _unityOfWork;

    // Infra Services
    private readonly IMailInfraService _mailInfraService;

    public TransfersService(IOptions<UserTypeNamesSettings> userTypeNamesSettings, ITransfersRepository transfersRepository, IUsersRepository usersRepository, IUserTypesRepository userTypesRepository, ICommonUserDAO commonUserDAO, ITransferDAO transferDAO, IUnityOfWork unityOfWork, IMailInfraService mailInfraService)
    {
        _userTypeNamesSettings = userTypeNamesSettings;

        _transfersRepository = transfersRepository;
        _usersRepository = usersRepository;
        _userTypesRepository = userTypesRepository;

        _commonUserDAO = commonUserDAO;
        _transferDAO = transferDAO;

        _unityOfWork = unityOfWork;

        _mailInfraService = mailInfraService;
    }

    public async Task<CreateTransferResponse> CreateTransfer(CreateTransferRequest request)
    {
        try
        {
            var transfer = new Transfer(
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

            MakeSenderUserValidations(isAdministratorSpecification, senderUserType);
            MakeReceiverUserValidations(isAdministratorSpecification, receiverUserType);

            await _transfersRepository.CreateTransfer(transfer);

            await DecreaseSenderUserBalance(senderUser, transfer.TransferAmount);
            await IncreaseReceiverUserBalance(receiverUser, receiverUserType, transfer.TransferAmount);

            await SendTransferMakedEmail(
                transferMailTo: TransferMailTo.TransferSender,
                mailReceiverEmail: senderUser.Email!.EmailText!,
                transferSenderName: senderUser.UserName!.NameText!,
                transferReceiverName: receiverUser.UserName!.NameText!,
                transferDateTime: transfer.TransferDateTime,
                transferAmount: transfer.TransferAmount
            );

            await SendTransferMakedEmail(
                transferMailTo: TransferMailTo.TransferReceiver,
                mailReceiverEmail: senderUser.Email!.EmailText!,
                transferSenderName: senderUser.UserName!.NameText!,
                transferReceiverName: receiverUser.UserName!.NameText!,
                transferDateTime: transfer.TransferDateTime,
                transferAmount: transfer.TransferAmount
            );

            await _unityOfWork.Commit();

            var response = new CreateTransferResponse(
                transferId: transfer.TransferId,
                transferDescription: transfer.TransferDescription!.DescriptionText!,
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


    private void MakeSenderUserValidations(IsAdministratorUserSpecification isAdministratorSpecification, UserType senderUserType)
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
        if (receiverUserType.TypeName!.NameText == _userTypeNamesSettings.Value.CommonTypeName)
        {
            CommonUser common = await _usersRepository.GetCommonUserByUserId(receiverUser.UserId);
            common.IncreaseMoney(increaseAmount);
        }
        else if (receiverUserType.TypeName!.NameText == _userTypeNamesSettings.Value.ShopkeeperTypeName)
        {
            Shopkeeper shopkeeper = await _usersRepository.GetShopkeeperByUserId(receiverUser.UserId);
            shopkeeper.IncreaseMoney(increaseAmount);
        }
        else
        {
            throw new ArgumentException("You can increase balance only for common and shopkeeper users.");
        }
    }

    private async Task SendTransferMakedEmail(string mailReceiverEmail, string transferSenderName, string transferReceiverName, DateTime transferDateTime, double transferAmount, TransferMailTo transferMailTo)
    {
        try
        {
            var mailRequest = new MailWithTemplateRequest(
                ReceiverEmail: mailReceiverEmail,
                MailTemplate: new TransferMakedMailTemplate(
                    transferSenderName,
                    transferReceiverName,
                    transferDateTime,
                    transferAmount,
                    transferMailTo
                )
            );

            await _mailInfraService.SendMailWithTemplateAsync(mailRequest);


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
}
