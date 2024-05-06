using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class AdministratorUserTest
{
    [Fact]
    public void CreateAdministratorUserCorrectly()
    {
        var administrator = new AdministratorUser(
            administratorName: "Matheus Macedo Santos",
            administratorCPF: "67778379847",
            userId: Guid.Empty
        );

        Assert.True(administrator.AdministratorName!.IsValid);
        Assert.True(administrator.AdministratorCPF!.IsValid);
    }
}
