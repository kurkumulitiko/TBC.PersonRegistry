using MediatR;
using TBC.PersonRegistry.Application.Commons;
using TBC.PersonRegistry.Application.DTOs;
using TBC.PersonRegistry.Application.DTOs.Filters;

namespace TBC.PersonRegistry.Application.Features.People.Queries.GetPeople;

public class GetPeopleQuery : IRequest<Pagination<GetPersonDTO>>
{
    public string? SearchQuery { get; set; }

    public PersonFilter? PersonFilter { get; set; }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }



}
