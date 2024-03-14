
namespace paysys.webapi.Domain.ValueObjects;

public class TransferStatus : ValueObject
{
    public string? Name { get; init; }

    public TransferStatus(string transferStatusName)
    {
        Name = transferStatusName;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name!;
    }
}
