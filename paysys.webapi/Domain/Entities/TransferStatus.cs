using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace paysys.webapi.Domain.Entities;

[Table("transfer_status")]
public class TransferStatus
{
    [Key]
    [Column("transfer_status_id")]
    public Guid TransferStatusId { get; private set; }

    [Column("transfer_status_name")]
    public string? TransferStatusName { get; private set; }

    private TransferStatus()
    {
    }

    public static TransferStatus Create(string transferStatusName)
    {
        var transferStatus = new TransferStatus();

        transferStatus.TransferStatusId = Guid.NewGuid();
        transferStatus.TransferStatusName = transferStatusName;

        return transferStatus;
    }
}
