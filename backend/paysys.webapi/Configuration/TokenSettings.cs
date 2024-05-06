namespace paysys.webapi.Configuration;

public class TokenSettings
{
    public string? SecurityKey { get; set; }
    public int HoursToExpiration { get; set; }
}
