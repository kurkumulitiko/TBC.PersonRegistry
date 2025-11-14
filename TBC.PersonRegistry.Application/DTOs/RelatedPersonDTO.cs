using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.DTOs;

public class RelatedPersonDTO
{
    public PersonRelationType RelationType { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string PrivateNumber { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public string City { get; set; } = string.Empty;
    public string PicturePath { get; set; } = string.Empty;
    public ICollection<PhoneDTO> PhoneNumbers { get; set; }

    public RelatedPersonDTO()
    {
        PhoneNumbers = new HashSet<PhoneDTO>();
    }
}

