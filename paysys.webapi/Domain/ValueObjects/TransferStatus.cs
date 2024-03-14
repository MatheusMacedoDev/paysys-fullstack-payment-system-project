
namespace paysys.webapi.Domain.ValueObjects;

public class TransferStatus : ValueObject
{
    public string? Name { get; init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name!;
    }
}
