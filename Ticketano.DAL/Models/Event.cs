using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ticketano.DAL.Models;

namespace Ticketano.DAL.Models;

public class Event: BaseEntity<int>
{
    
    public string Key { get; set; }
    public string Name { get; set; }
    public string About { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string MainSiteUrl { get; set; }
    [Required]
    public string Currency { get; set; }
    [Required]
    public string Language { get; set; }
    public string AdminNotes { get; set; }
    public string AccountId { get; set; }
    public DateTime TrialExpiresAt { get; set; }
    public DateTime? DataJsUpdatedAt { get; set; }
    public decimal MonthlyPrice { get; set; }
    public bool EnableCharging { get; set; }
    public int PackageId { get; set; }
    public string DecimalSeparator { get; set; }
    public string NumberGroupSeparator { get; set; }
    public string VenueName { get; set; }
    public string VenueInfo { get; set; }
    public int LogoFileId { get; set; }
    public bool IsOnline { get; set; } = false;
    public string Duration { get; set; }
    public int ViewsCount { get; set; }
    
    [ForeignKey(nameof(AccountId))]
    public virtual User Account { get; set; }
    [ForeignKey(nameof(PackageId))]
    public virtual Package Package { get; set; }
    [ForeignKey(nameof(LogoFileId))]
    public virtual EventFile Logo { get; set; }
}