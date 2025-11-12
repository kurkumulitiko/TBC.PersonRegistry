using Mapster;
using MediatR;
using TBC.PersonRegistry.Application.Commons;
using TBC.PersonRegistry.Application.DTOs;
using TBC.PersonRegistry.Application.Interfaces;

namespace TBC.PersonRegistry.Application.Features.People.Queries.GetPeople;

public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, Pagination<GetPersonDTO>>
{
    private readonly IUnitOfWork _uow;

    public GetPeopleQueryHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task<Pagination<GetPersonDTO>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        var people = await _uow.PersonRepository.FilterAsync(request.PageIndex, request.PageSize, request.SearchQuery, request.PersonFilter, cancellationToken);

        return people.Adapt<Pagination<GetPersonDTO>>();
    }
}
