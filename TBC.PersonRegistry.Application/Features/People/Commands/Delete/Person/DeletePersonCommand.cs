using MediatR;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Delete.Person;

public class DeletePersonCommand : IRequest
{
    public int Id { get; set; }
}

