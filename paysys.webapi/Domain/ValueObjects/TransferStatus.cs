using System.ComponentModel.DataAnnotations.Schema;

namespace paysys.webapi.Domain.ValueObjects;

public class TransferStatus : ValueObject
{
    [Column("transfer_status_name")]
    public string? TransferStatusName { get; private set; }

    public TransferStatus(string transferStatusName)
    {
        TransferStatusName = transferStatusName;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return TransferStatusName!;
    }
}
