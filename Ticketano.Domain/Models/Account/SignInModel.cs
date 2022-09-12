using System.ComponentModel.DataAnnotations;

namespace Ticketano.Domain.Models;

public class SignInModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}