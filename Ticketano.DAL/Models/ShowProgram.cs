using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketano.DAL.Models;

public class ShowProgram: BaseEntity<int>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Name { get; set; }
    public string About { get; set; }
    public int EventId { get; set; }
    
    [ForeignKey(nameof(EventId))]
    public virtual Event Event { get; set; }
}