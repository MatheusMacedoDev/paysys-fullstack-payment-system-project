namespace paysys.webapi.Infra.Data.UnityOfWork;

public class UnityOfWork : IUnityOfWork
{
    private readonly DataContext _context;

    public UnityOfWork(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        var haveSuccess = (await _context.SaveChangesAsync()) > 0;

        return haveSuccess;
    }

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
