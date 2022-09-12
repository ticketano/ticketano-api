using System.ComponentModel.DataAnnotations.Schema;
using Ticketano.DAL.Enums;

namespace Ticketano.DAL.Models;

public class Ticket: BaseEntity<int>
{
    public int SessionId { get; set; }
    public int? HallId { get; set; }
    public int? PlaceId { get; set; }
    public decimal Price { get; set; }
    public string BuyerId { get; set; }
    public int StatusId { get; set; }
    public int TypeId { get; set; }
    
    [ForeignKey(nameof(SessionId))]
    public virtual Session Session { get; set; }
    [ForeignKey(nameof(PlaceId))]
    public virtual Place Place { get; set; }
    [ForeignKey(nameof(BuyerId))]
    public virtual User Buyer { get; set; }
    [ForeignKey(nameof(TypeId))]
    public virtual TicketType TicketType { get; set; }
    [ForeignKey(nameof(StatusId))]
    public TicketStatus Status { get; set; }
}