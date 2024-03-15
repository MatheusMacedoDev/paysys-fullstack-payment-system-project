using System.ComponentModel.DataAnnotations.Schema;

namespace paysys.webapi.Domain.ValueObjects;

public class TransferCategory : ValueObject
{
    [Column("transfer_category_name")]
    public string? TransferCategoryName { get; private set; }

    public TransferCategory(string transferCategoryName)
    {
        TransferCategoryName = transferCategoryName;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return TransferCategoryName!;
    }
}
