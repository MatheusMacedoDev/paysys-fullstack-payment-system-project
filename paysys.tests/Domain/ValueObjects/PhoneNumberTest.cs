using paysys.webapi.Domain.ValueObjects;

namespace paysys.tests.Domain.ValueObjects;

public class PhoneNumberTest
{
    [Fact]
    public void CreateValidPhoneNumber()
    {
        PhoneNumber testedPhoneNumber = new PhoneNumber("11984236577");

        if (!testedPhoneNumber.IsValid)
        {
            foreach (var notification in testedPhoneNumber.Notifications)
            {
                Console.WriteLine(notification.Message);
            }
        }

        Assert.True(testedPhoneNumber.IsValid);
    }

    [Fact]
    public void CreateInvalidPhoneNumber()
    {
        Action actual = () => new PhoneNumber("1198423657A");

        Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void GetFormattedPhoneNumberTest()
    {
        PhoneNumber testedPhoneNumber = new PhoneNumber("11984236577");
        string expectedFormattedPhoneNumber = "(11) 98423-6577";

        string formattedPhoneNumber = testedPhoneNumber.GetFormattedPhoneNumber();

        Assert.Equal(expectedFormattedPhoneNumber, formattedPhoneNumber);
    }
}
