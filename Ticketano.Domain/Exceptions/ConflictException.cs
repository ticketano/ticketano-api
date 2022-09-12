namespace Ticketano.Domain.Exceptions;

public class ConflictException : BusinessException
{
    public override int StatusCode => 409;

    public ConflictException(string message) : base(message)
    {
    }
}