using Microsoft.Extensions.Options;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Domain.Specifications;

public class HaveEnoughMoneySpecification : AsyncSpecification<Transfer>
{
    // Configurations
    private readonly string CommonUserTypeName;
    private readonly string ShopkeeperUserTypeName;

    // Repositories
    private readonly IUsersRepository _usersRepository;
    private readonly IUserTypesRepository _userTypesRepository;

    public HaveEnoughMoneySpecification(IOptions<UserTypeNamesSettings> settings, IUsersRepository usersRepository, IUserTypesRepository userTypesRepository)
    {
        CommonUserTypeName = settings.Value.CommonTypeName!;
        ShopkeeperUserTypeName = settings.Value.ShopkeeperTypeName!;

        _usersRepository = usersRepository;
        _userTypesRepository = userTypesRepository;
    }

    public async Task<bool> IsSatisfiedBy(Transfer transfer)
    {
        double requiredMoneyAmount = transfer.TransferAmount;

        try
        {
            User senderUser = await _usersRepository.GetUserById(transfer.SenderUserId);
            UserType senderUserType = await _userTypesRepository.GetUserType(senderUser.UserId)!;

            if (senderUserType.TypeName == CommonUserTypeName)
            {
                CommonUser commonSenderUser = await _usersRepository.GetCommonUserByUserId(senderUser.UserId);

                return commonSenderUser.Balance >= transfer.TransferAmount;
            }
            else if (senderUserType.TypeName == ShopkeeperUserTypeName)
            {
                Shopkeeper shopkeeperSender = await _usersRepository.GetShopkeeperByUserId(senderUser.UserId);

                return shopkeeperSender.Balance >= transfer.TransferAmount;
            }
            else
            {
                throw new ArgumentException("Invalid sender user type name.");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
