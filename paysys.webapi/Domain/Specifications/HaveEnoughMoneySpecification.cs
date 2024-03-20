using Microsoft.Extensions.Options;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Infra.Data.DAOs.Interfaces;

namespace paysys.webapi.Domain.Specifications;

public class HaveEnoughMoneySpecification : AsyncSpecification<Transfer>
{
    // Configurations
    private readonly string CommonUserTypeName;
    private readonly string ShopkeeperUserTypeName;

    // Data
    private readonly Guid SenderUserId;
    private readonly string SenderUserTypeName;

    // DAOs
    private readonly ICommonUserDAO _commonUserDAO;


    public HaveEnoughMoneySpecification(IOptions<UserTypeNamesSettings> settings, Guid senderUserId, string senderUserTypeName, ICommonUserDAO commonUserDAO)
    {
        CommonUserTypeName = settings.Value.CommonTypeName!;
        ShopkeeperUserTypeName = settings.Value.ShopkeeperTypeName!;

        SenderUserId = senderUserId;
        SenderUserTypeName = senderUserTypeName;

        _commonUserDAO = commonUserDAO;
    }

    public async Task<bool> IsSatisfiedBy(Transfer transfer)
    {
        double requiredMoneyAmount = transfer.TransferAmount;

        try
        {
            if (SenderUserTypeName == CommonUserTypeName)
            {
                double commonUserBalance = await _commonUserDAO.GetCommonUserBalanceByUserId(SenderUserId);

                return commonUserBalance >= requiredMoneyAmount;
            }
            else
            {
                throw new ArgumentException("Invalid sender user type name. Have enough money specification is maked only for common users.");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
