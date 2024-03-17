using Microsoft.Extensions.Options;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Specifications;

public class IsNotAdministratorUserSpecification : Specification<UserType>
{
    // Configurations
    private readonly string? AdministratorTypeName;

    public IsNotAdministratorUserSpecification(IOptions<UserTypeNamesSettings> settings)
    {
        AdministratorTypeName = settings.Value.AdministratorTypeName;
    }

    public bool IsSatisfiedBy(UserType type)
    {
        try
        {
            if (type.TypeName != AdministratorTypeName)
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
