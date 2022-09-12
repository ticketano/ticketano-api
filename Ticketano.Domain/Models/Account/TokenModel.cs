namespace Ticketano.Domain.Models;


public class TokenModel
{
    public bool Successed { get; set; } = false;

    public string Jwt { get; set; }

    public UserModel User { get; set; }
}