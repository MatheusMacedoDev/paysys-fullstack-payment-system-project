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

        if (!administrator.IsValid)
        {
            foreach (var notification in administrator.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(administrator.IsValid);
    }

    [Fact]
    public void CreateAdministratorUserWithCPF()
    {
        var administrator = new AdministratorUser(
            administratorName: "Matheus Macedo santos",
            administratorCPF: "6777837984e",
            userId: Guid.Empty
        );

        var isCPFInvalid = IsUserPropertyInvalid(administrator, "AdministratorCPF");

        Assert.True(isCPFInvalid);
        Assert.False(administrator.IsValid);
    }

    private bool IsUserPropertyInvalid(AdministratorUser administrator, string propertyName)
    {
        if (!administrator.IsValid)
        {
            foreach (var notification in administrator.Notifications)
            {
                if (notification.Key == propertyName)
                {
                    return true;
                }
            }
        }

        return false;

    }
}
