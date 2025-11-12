using MediatR;
using Microsoft.AspNetCore.Http;


namespace TBC.PersonRegistry.Application.Features.People.Commands;

public class UploadPersonImageCommand : IRequest
{
    public int PersonId { get; set; }
    public IFormFile Image { get; set; }

}
