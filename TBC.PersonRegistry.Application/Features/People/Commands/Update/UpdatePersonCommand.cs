using MediatR;
using TBC.PersonRegistry.Application.DTOs;
using TBC.PersonRegistry.Domain.Enums;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Update;

public record class UpdatePersonCommand : IRequest
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender Gender { get; set; }
    public string? PrivateNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public ICollection<PhoneDTO> Phones { get; set; }

    public UpdatePersonCommand()
    {
        Phones = new HashSet<PhoneDTO>();
    }
    public UpdatePersonCommand SetPersonId(int personId)
    {
        PersonId = personId;
        return this;
    }



}

