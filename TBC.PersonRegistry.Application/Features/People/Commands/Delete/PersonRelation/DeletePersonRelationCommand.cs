using MediatR;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Delete.PersonRelation;

public class DeletePersonRelationCommand : IRequest
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
}
