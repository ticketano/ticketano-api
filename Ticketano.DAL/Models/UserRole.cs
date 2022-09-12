using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Ticketano.DAL.Models;

public class UserRole : IdentityUserRole<string>
{
    [Column("UserId")]
    [ForeignKey(nameof(User))]
    public override string UserId { get; set; }
    [Column("RoleId")]
    public override string RoleId { get; set; }

}