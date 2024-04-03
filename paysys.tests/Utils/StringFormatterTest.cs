using paysys.webapi.Utils;

namespace paysys.tests.Utils;

public class StringFormatterTest
{
    [Fact]
    public void BasicClearTest()
    {
        string dirtyText = " Matheus   Macedo Santos   ";
        string expectedCleanText = "Matheus Macedo Santos";

        string cleanText = StringFormatter.BasicClear(dirtyText);

        Assert.Equal(expectedCleanText, cleanText);
    }

    [Fact]
    public void FullyClearTest()
    {
        string dirtyText = " 787.378.698-37 ";
        string expectedCleanText = "78737869837";

        string cleanText = StringFormatter.FullyClear(dirtyText);

        Assert.Equal(expectedCleanText, cleanText);
    }
}
