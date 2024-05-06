namespace paysys.webapi.Infra.Data.UnityOfWork;

public interface IUnityOfWork
{
    Task<bool> Commit();
    Task Rollback();
}
