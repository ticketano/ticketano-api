using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ticketano.DAL.Models;
using Ticketano.Domain.Constants;
using Ticketano.Domain.Models.Event;

namespace Ticketano.DAL.Repositories;

public class EventRepository: BaseRepository<Event>
{
    private readonly IConfiguration _configuration;
    public EventRepository(ApplicationDbContext db, IConfiguration configuration) : base(db)
    {
        _configuration = configuration;
    }

    public async Task<int> Add(AddEventModel evnt)
    {
        var sampleEventKey = _configuration["SampleEventKey"];
        var newId = await Clone(sampleEventKey, evnt.Key);
        return newId;
    }

    public async Task<Event> GetFullById(int id)
    {
        return await Db.Events
            .Include(x => x.Account)
            .Include(x => x.Logo)
            .Include(x => x.Package)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<Event> GetFullByKey(string eventKey)
    {
        return await Db.Events
            .Include(x => x.Account)
            .Include(x => x.Logo)
            .Include(x => x.Package)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Key == eventKey);
    }

    public async Task<int> Clone(string srcEventKey, string destEventKey)
    {
        var evnt = await GetFullByKey(srcEventKey);
        evnt.Id = 0;
        evnt.Key = destEventKey;
        Db.Update(evnt);
        await SaveChangesAsync();

        return evnt.Id;
    }
}