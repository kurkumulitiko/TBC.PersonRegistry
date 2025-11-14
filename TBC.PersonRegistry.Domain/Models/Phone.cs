using TBC.PersonRegistry.Domain.Basics;
using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Domain.Models;

public class Phone : AuditableEntity
{
    public PhoneNumberType NumberType { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public int PersonId { get; set; }
    public Person Person { get; set; }

}

