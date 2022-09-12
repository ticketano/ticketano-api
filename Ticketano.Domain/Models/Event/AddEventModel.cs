using System.ComponentModel.DataAnnotations;

namespace Ticketano.Domain.Models.Event;

public class AddEventModel
{
    [Required]
    public string Key { get; set; }
    [Required]
    public string Name { get; set; }
}