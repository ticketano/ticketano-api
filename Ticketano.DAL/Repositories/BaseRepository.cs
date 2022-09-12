using Microsoft.EntityFrameworkCore;

namespace Ticketano.DAL.Repositories;

public abstract class BaseRepository<T> where T : class
{
    protected readonly ApplicationDbContext Db;

    public BaseRepository(ApplicationDbContext db)
    {
        Db = db;
    }

    public void Add(T entity)
    {
        Db.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        Db.Set<T>().AddRange(entities);
    }

    public void Delete(T entity)
    {
        Db.Entry(entity).State = EntityState.Deleted;
    }

    public void SaveChanges()
    {
        Db.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await Db.SaveChangesAsync();
    }
}