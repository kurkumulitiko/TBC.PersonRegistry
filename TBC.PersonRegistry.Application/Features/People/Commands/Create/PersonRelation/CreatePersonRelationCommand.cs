using MediatR;
using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Create.PersonRelation;

public class CreatePersonRelationCommand : IRequest
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
    public PersonRelationType RelationType { get; set; }
    
}

