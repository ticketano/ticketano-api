using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketano.DAL.Models;

public class Place: BaseEntity<int>
{
    public string Name { get; set; }
    public int SessionId { get; set; }
    public int? Row { get; set; }
    public int TypeId { get; set; }
    public decimal Price { get; set; }
    
    [ForeignKey(nameof(SessionId))]
    public virtual Session Session { get; set; }
    [ForeignKey(nameof(TypeId))]
    public virtual PlaceType Type { get; set; }
}