using Microsoft.Extensions.Options;
using paysys.webapi.Configuration;
using paysys.webapi.Domain.Entities;

namespace paysys.webapi.Domain.Specifications;

public class IsShopkeeperSpecification : Specification<UserType>
{
    // Configurations
    private readonly string? ShopkeeperTypeName;

    public IsShopkeeperSpecification(IOptions<UserTypeNamesSettings> settings)
    {
        ShopkeeperTypeName = settings.Value.ShopkeeperTypeName;
    }

    public bool IsSatisfiedBy(UserType type)
    {
        return type.TypeName!.NameText == ShopkeeperTypeName;
    }
}
