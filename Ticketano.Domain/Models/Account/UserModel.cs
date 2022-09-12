namespace Ticketano.Domain.Models;

public class UserModel
{
    public string Id { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? IsActive { get; set; }
}