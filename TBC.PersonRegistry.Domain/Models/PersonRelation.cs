using TBC.PersonRegistry.Domain.Basics;
using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Domain.Models;

public class PersonRelation : AuditableEntity
{
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int RelatedPersonId { get; set; }
    public Person RelatedPerson { get; set; }
    public PersonRelationType RelationType { get; set; }
}

