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

        Assert.True(common.CommonUserName!.IsValid);
        Assert.True(common.CommonUserCPF!.IsValid);
    }
}
