using paysys.webapi.Domain.Entities;

namespace paysys.tests.Domain.Entities;

public class CommonUserTest
{
    [Fact]
    public void CreateCommonUserCorrectly()
    {
        var common = new CommonUser(
            commonUserName: "Matheus Macedo Santos",
            commonUserCPF: "67778379847",
            userId: Guid.Empty
        );

        if (!common.IsValid)
        {
            foreach (var notification in common.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(common.IsValid);
    }

    [Fact]
    public void CreateCommonUserWithIncorrectName()
    {
        var common = new CommonUser(
            commonUserName: "Matheus macedo Santos",
            commonUserCPF: "67778379847",
            userId: Guid.Empty
        );

        var isCommonUserNameInvalid = IsUserPropertyInvalid(common, "CommonUserName");

        Assert.True(isCommonUserNameInvalid);
        Assert.False(common.IsValid);
    }

    [Fact]
    public void CreateCommonUserWithIncorrectCPF()
    {
        var common = new CommonUser(
            commonUserName: "Matheus macedo Santos",
            commonUserCPF: "677783x98c7",
            userId: Guid.Empty
        );

        var isCPFInvalid = IsUserPropertyInvalid(common, "CommonUserCPF");

        Assert.True(isCPFInvalid);
        Assert.False(common.IsValid);
    }

    private bool IsUserPropertyInvalid(CommonUser common, string propertyName)
    {
        if (!common.IsValid)
        {
            foreach (var notification in common.Notifications)
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
