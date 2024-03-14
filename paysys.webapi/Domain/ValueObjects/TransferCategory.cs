namespace paysys.webapi.Domain.ValueObjects;

public class TransferCategory : ValueObject
{
    public string? Name { get; init; }

    public TransferCategory(string transferCategoryName)
    {
        Name = transferCategoryName;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name!;
    }
}
