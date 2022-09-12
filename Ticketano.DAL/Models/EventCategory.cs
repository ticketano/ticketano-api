namespace Ticketano.DAL.Models;

public class EventCategory
{
    public int CategoryId { get; set; }
    public int EventId { get; set; }
    
    public Category Category { get; set; }
    public Event Event { get; set; }
}