using System.Net;

namespace TBC.PersonRegistry.Application.Exceptions;

public abstract class ApiValidationException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public ApiValidationException(string message) : base(message) { }
}

