using paysys.webapi.Application.Contracts.Requests;
using paysys.webapi.Application.Contracts.Responses;

namespace paysys.webapi.Application.Services.UsersService;

public interface IUsersService
{
    Task<CreateAdministratorResponse> CreateAdministrator(CreateAdministratorRequest request);
    Task<CreateCommonUserResponse> CreateCommonUser(CreateCommonUserRequest request);
    Task<GetShortCommonUsersResponse> GetShortCommonUsers();
    Task<GetFullCommonUserResponse> GetFullCommonUser(GetFullCommonUserRequest request);
    Task<CreateShopkeeperResponse> CreateShopkeeper(CreateShopkeeperRequest request);
    Task<GetShortShopkeeperResponse> GetShortShopkeepers();
}
