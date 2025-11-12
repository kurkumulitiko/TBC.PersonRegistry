using MediatR;
using TBC.PersonRegistry.Application.DTOs;
using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Create.Person;

public record class CreatePersonCommand : IRequest<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string PrivateNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }

    public IEnumerable<PhoneDTO> Phones { get; set; }
    public CreatePersonCommand()
    {
        Phones = new HashSet<PhoneDTO>();
    }

}

