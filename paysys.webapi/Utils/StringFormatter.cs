using System.Globalization;
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
        cleanText = Regex.Replace(cleanText, "[^A-Za-z0-9]", String.Empty);

        return cleanText;
    }

    public static string FormatToTitle(string text)
    {
        var lowerCaseName = text.ToLower();
        var pascalCaseName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lowerCaseName);

        return pascalCaseName;
    }
}
