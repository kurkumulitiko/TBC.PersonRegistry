using MediatR;
using TBC.PersonRegistry.Application.DTOs;

namespace TBC.PersonRegistry.Application.Features.People.Queries.GetPersonDetails;

public class GetPersonDetailsQuery : IRequest<GetPersonDTO>
{
    public int Id { get; set; }
}
