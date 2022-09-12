namespace Ticketano.Domain.Exceptions;

public abstract class BusinessException: Exception
{
    public abstract int StatusCode { get; }

    protected BusinessException()
    {
    }

    protected BusinessException(string message) : base(message)
    {
    }
}