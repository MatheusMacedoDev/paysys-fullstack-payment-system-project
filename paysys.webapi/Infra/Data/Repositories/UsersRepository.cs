using Microsoft.EntityFrameworkCore;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Infra.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DataContext _context;

    public UsersRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateAdministratorUser(AdministratorUser administrator)
    {
        await _context.AdministratorUsers!.AddAsync(administrator);
    }

    public Task<AdministratorUser> GetAdministratorById(Guid administratorId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAdministrator(Guid administratorId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateUser(User user)
    {
        await _context.Users!.AddAsync(user);
    }

    public async Task<User> GetUserById(Guid userId)
    {
        return (await _context.Users!.FirstOrDefaultAsync(user => user.UserId == userId))!;
    }

    public Task DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateCommonUser(CommonUser commonUser)
    {
        await _context.CommonUsers!.AddAsync(commonUser);
    }

    public Task<CommonUser> GetCommonUserById(Guid commonUserId)
    {
        throw new NotImplementedException();
    }

    public async Task CreateShopkeeper(Shopkeeper shopkeeper)
    {
        await _context.Shopkeepers!.AddAsync(shopkeeper);
    }

    public Task<Shopkeeper> GetShopkeeperById(Guid shopkeeperId)
    {
        throw new NotImplementedException();
    }

    public async Task<CommonUser> GetCommonUserByUserId(Guid userId)
    {
        return (await _context.CommonUsers!
            .AsTracking()
            .FirstOrDefaultAsync(common => common.UserId == userId))!;
    }

    public async Task<Shopkeeper> GetShopkeeperByUserId(Guid userId)
    {
        return (await _context.Shopkeepers!
            .AsTracking()
            .FirstOrDefaultAsync(shopkeeper => shopkeeper.UserId == userId))!;
    }
}
