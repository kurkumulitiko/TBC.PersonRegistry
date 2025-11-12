using System.Net;

namespace TBC.PersonRegistry.Application.Exceptions
{
    public class AlreadyExistsException : ApiValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public AlreadyExistsException(string message) : base(message) { }
    }
}
