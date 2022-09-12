using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketano.DAL.Models;

public class Category: BaseEntity<int>
{
    public string Name { get; set; }
    
    public int ParentId { get; set; }
    [ForeignKey(nameof(ParentId))]
    public Category Parent { get; set; }
}