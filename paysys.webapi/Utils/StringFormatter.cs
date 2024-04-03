using System.Text.RegularExpressions;

namespace paysys.webapi.Utils;

public static class StringFormatter
{
    public static string BasicClear(string dirtyText)
    {
        string cleanText;

        cleanText = dirtyText.Trim();
        cleanText = Regex.Replace(cleanText, "\\s+", " ");

        return cleanText;
    }

    public static string FullyClear(string dirtyText)
    {
        string cleanText;

        cleanText = BasicClear(dirtyText);
        cleanText = Regex.Replace(cleanText, "[?&^$#@!()+-,:;<>’\'-_*]", String.Empty);

        return cleanText;
    }
}
