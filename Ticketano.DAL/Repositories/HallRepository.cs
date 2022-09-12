using Ticketano.DAL.Models;

namespace Ticketano.DAL.Repositories;

public class HallRepository: BaseRepository<Hall>
{
    public HallRepository(ApplicationDbContext db) : base(db)
    {
    }
}