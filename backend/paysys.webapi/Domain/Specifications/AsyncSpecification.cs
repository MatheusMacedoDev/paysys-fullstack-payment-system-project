namespace paysys.webapi.Domain.Specifications;

public interface AsyncSpecification<T>
{
    Task<bool> IsSatisfiedBy(T entity);
}
