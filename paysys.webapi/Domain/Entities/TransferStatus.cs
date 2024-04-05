using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using paysys.webapi.Domain.ValueObjects;

namespace paysys.webapi.Domain.Entities;

[Table("transfer_status")]
public class TransferStatus
{
    [Key]
    [Column("transfer_status_id")]
    public Guid TransferStatusId { get; private set; }

    public Name? TransferStatusName { get; private set; }

    protected TransferStatus()
    {
    }

    public TransferStatus(string transferStatusName)
    {
        TransferStatusId = Guid.NewGuid();

        TransferStatusName = new Name(
            nameText: transferStatusName,
            maxCharacters: 4
        );
    }
}
