using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketano.DAL.Models;

public class EventFile: BaseEntity<int>
{
    public string FileName { get; set; }
    public int EventId { get; set; }
    
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }
}