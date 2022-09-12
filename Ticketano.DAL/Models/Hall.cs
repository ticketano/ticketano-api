using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketano.DAL.Models;

public class Hall: BaseEntity<int>
{
    public string Name { get; set; }
    public int EventId { get; set; }
    public int PlacesCount { get; set; }
    public decimal Price { get; set; }
    
    [ForeignKey(nameof(EventId))]
    public virtual Event Event { get; set; }
}