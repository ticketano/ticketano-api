using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ticketano.DAL.Models;

public class Role: IdentityRole<string>
{
}