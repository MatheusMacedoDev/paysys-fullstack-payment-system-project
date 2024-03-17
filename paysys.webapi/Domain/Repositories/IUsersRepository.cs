using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Interfaces.Repositories;

public interface IUsersRepository
{
    Task CreateUser(User user);
    Task<User> GetUserById(Guid userId);
    Task DeleteUser(Guid userId);

    Task CreateAdministratorUser(AdministratorUser administrator);
    Task<AdministratorUser> GetAdministratorById(Guid administratorId);
    Task DeleteAdministrator(Guid administratorId);

    Task CreateCommonUser(CommonUser commonUser);
    Task<CommonUser> GetCommonUserById(Guid commonUserId);
    Task<CommonUser> GetCommonUserByUserId(Guid userId);

    Task CreateShopkeeper(Shopkeeper shopkeeper);
    Task<Shopkeeper> GetShopkeeperById(Guid shopkeeperId);
    Task<Shopkeeper> GetShopkeeperByUserId(Guid userId);
}
