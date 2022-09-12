namespace Ticketano.Domain.Exceptions;

public class ForbiddenException: BusinessException
{
    public override int StatusCode => 401;
    
    public ForbiddenException(string message) : base(message)
    {
    }
}