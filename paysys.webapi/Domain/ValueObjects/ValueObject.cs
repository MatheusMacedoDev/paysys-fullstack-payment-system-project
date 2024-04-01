using Flunt.Notifications;

namespace paysys.webapi.Domain.ValueObjects;

public abstract class ValueObject : Notifiable<Notification>, IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? obj1, ValueObject? obj2)
    {
        if (obj1 is null && obj2 is null)
        {
            return true;
        }

        if (obj1 is null || obj2 is null)
        {
            return false;
        }

        return obj1.Equals(obj2);
    }

    public static bool operator !=(ValueObject? obj1, ValueObject? obj2) =>
        !(obj1 == obj2);

    public virtual bool Equals(ValueObject? other) =>
        other is not null && ValuesAreEqual(other);

    public override bool Equals(object? obj) =>
        obj is ValueObject valueObject && ValuesAreEqual(valueObject);

    public override int GetHashCode() =>
        GetAtomicValues().Aggregate(
                default(int),
                (hashCode, value) =>
                    HashCode.Combine(hashCode, value.GetHashCode()));

    protected abstract IEnumerable<object> GetAtomicValues();

    private bool ValuesAreEqual(ValueObject valueObject) =>
        GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
}
