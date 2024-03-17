using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Domain.Specifications;

public class HaveEnoughMoneySpecification : AsyncSpecification<Transfer>
{
    // Configurations
    private const string CommonUserTypeName = "Comum";
    private const string ShopkeeperUserTypeName = "Lojista";

    // Repositories
    private readonly IUsersRepository _usersRepository;
    private readonly IUserTypesRepository _userTypesRepository;

    public HaveEnoughMoneySpecification(IUsersRepository usersRepository, IUserTypesRepository userTypesRepository)
    {
        _usersRepository = usersRepository;
        _userTypesRepository = userTypesRepository;
    }

    public async Task<bool> IsSatisfiedBy(Transfer transfer)
    {
        double requiredMoneyAmount = transfer.TransferAmount;

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
}
