using System.Net;

namespace ZooSystem.Exceptions;

public class ErrorOnValidationException : ZooSystemException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }
    public override List<string> GetErrorMessages() => _errors;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}
