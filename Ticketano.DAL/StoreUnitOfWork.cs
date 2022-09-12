namespace Ticketano.DAL;

public class StoreUnitOfWork: IDisposable
{
    private readonly ApplicationDbContext db;

    public StoreUnitOfWork(ApplicationDbContext db)
    {
        this.db = db;
    }

    public void Dispose()
    {
        db.Dispose();
    }
}