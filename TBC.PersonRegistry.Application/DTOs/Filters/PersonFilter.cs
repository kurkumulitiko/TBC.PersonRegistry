using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.DTOs.Filters;

public class PersonFilter
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PrivateNumber { get; set; }
    public DateTime? BirthDate { get; set; } = null;
    public int CityId { get; set; }
    public Gender? Gender { get; set; }
    public string City { get; set; }
}
