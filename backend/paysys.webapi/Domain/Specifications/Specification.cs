namespace paysys.webapi.Domain.Specifications;

public interface Specification<T>
{
    bool IsSatisfiedBy(T entity);
}
