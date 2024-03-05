namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public class ShortCommonUserTO
{
    public Guid CommonUserId { get; set; }
    public string? CommonUserName { get; set; }
    public string? CommonUserEmail { get; set; }
}
