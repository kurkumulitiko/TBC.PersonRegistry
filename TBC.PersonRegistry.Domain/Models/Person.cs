using TBC.PersonRegistry.Domain.Basics;
using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Domain.Models;

public class Person : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string PrivateNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public ICollection<Phone> Phones { get; set; }
    public string? ImagePath { get; set; }
    public ICollection<PersonRelation> RelatedPeople { get; set; }

    public Person()
    {
        Phones = new HashSet<Phone>();
        RelatedPeople = new HashSet<PersonRelation>();
    }
}

