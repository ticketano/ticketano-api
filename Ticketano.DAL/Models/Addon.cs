namespace Ticketano.DAL.Models;

public class Addon: BaseEntity<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool IsHidden { get; set; }
}