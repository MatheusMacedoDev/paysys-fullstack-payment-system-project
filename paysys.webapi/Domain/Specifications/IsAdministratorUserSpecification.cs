using Microsoft.Extensions.Options;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Specifications;

public class IsAdministratorUserSpecification : Specification<UserType>
{
    // Configurations
    private readonly string? AdministratorTypeName;

    public IsAdministratorUserSpecification(IOptions<UserTypeNamesSettings> settings)
    {
        AdministratorTypeName = settings.Value.AdministratorTypeName;
    }

    public bool IsSatisfiedBy(UserType type)
    {
        try
        {
            if (type.TypeName == AdministratorTypeName)
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
