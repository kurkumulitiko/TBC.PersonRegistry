using System.Net;

namespace TBC.PersonRegistry.Application.Exceptions;

public class NotFoundException : ApiValidationException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public NotFoundException(string message) : base(message) { }
}

