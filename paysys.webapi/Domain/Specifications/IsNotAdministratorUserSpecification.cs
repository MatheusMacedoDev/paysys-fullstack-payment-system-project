using Microsoft.Extensions.Options;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;
using paysys.webapi.Domain.Interfaces.Repositories;

namespace paysys.webapi.Domain.Specifications;

public class IsNotAdministratorUserSpecification : AsyncSpecification<User>
{
    // Configurations
    private readonly string? AdministratorTypeName;

    // Repositories
    private readonly IUserTypesRepository _userTypesRepository;

    public IsNotAdministratorUserSpecification(IOptions<UserTypeNamesSettings> settings, IUserTypesRepository userTypesRepository)
    {
        AdministratorTypeName = settings.Value.AdministratorTypeName;

        _userTypesRepository = userTypesRepository;
    }

    public async Task<bool> IsSatisfiedBy(User user)
    {
        try
        {
            UserType userType = await _userTypesRepository.GetUserType(user.UserTypeId)!;

            if (userType.TypeName != AdministratorTypeName)
            {
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
