using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.DTOs;

    public class GetPersonDTO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public CityDTO City { get; set; }
        public string ImagePath { get; set; }
        public ICollection<PhoneDTO> Phones { get; set; }
        public ICollection<RelatedPersonDTO> RelatedPeople { get; set; }

    public GetPersonDTO()
    {
        Phones = new HashSet<PhoneDTO>();
        RelatedPeople = new HashSet<RelatedPersonDTO>();
    }
}

