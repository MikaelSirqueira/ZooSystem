using System.Net;

namespace ZooSystem.Exceptions;

public abstract class ZooSystemException : SystemException
{
    public ZooSystemException(string? message) : base(message) { }

    public abstract List<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();

}
