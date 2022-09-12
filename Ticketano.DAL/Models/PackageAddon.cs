using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketano.DAL.Models;

public class PackageAddon: BaseEntity<int>
{
    public int AddonId { get; set; }
    public int PackageId { get; set; }
    
    [ForeignKey(nameof(AddonId))]
    public virtual Addon Addon { get; set; }
    [ForeignKey(nameof(PackageId))]
    public virtual Package Package { get; set; }
}