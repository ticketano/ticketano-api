using Ticketano.DAL.Repositories;
using Ticketano.Domain.Models.Event;

namespace Ticketano.BLL.Services;

public class EventService: BaseService
{
    private readonly EventRepository _eventRepository;
    
    public EventService(EventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<int> Add(AddEventModel evnt)
    {
        return await _eventRepository.Add(evnt);
    }
}