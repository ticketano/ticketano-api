using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Ticketano.DAL.Enums;

namespace Ticketano.DAL.Models;

public class User: IdentityUser<string>
{
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public string CompanyName { get; set; } = "";
    public string Address { get; set; } = "";
    public string Address2 { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string Zip { get; set; } = "";
    public PaymentProcessor PaymentProcessor { get; set; } = PaymentProcessor.NotSet;
    public string AdminNotes { get; set; } = "";
    public bool? IsActive { get; set; } = false;
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [DefaultValue("now() at time zone 'utc')")]
    public DateTime LastActiveAt { get; set; } = DateTime.Now;
    
    [InverseProperty(nameof(Event.Account))]
    public virtual ICollection<Event> Events { get; set; }
}