namespace paysys.webapi.Infra.Data.DAOs.TransferObjects;

public class FullCommonUserTO
{
    public Guid CommonUserId { get; set; }
    public string? CommonUserRealName { get; set; }
    public string? CommonUsername { get; set; }
    public string? CommonUserEmail { get; set; }
    public string? CommonUserPhoneNumber { get; set; }
    public string? UserTypeName { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
