using System.ComponentModel.DataAnnotations;

namespace Ticketano.DAL.Models;

public class TicketType: BaseEntity<int>
{
    public string Name { get; set; }
}