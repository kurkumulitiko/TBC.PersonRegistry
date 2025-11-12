using Mapster;
using MediatR;
using TBC.PersonRegistry.Application.DTOs;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Interfaces;

namespace TBC.PersonRegistry.Application.Features.People.Queries.GetPersonDetails;

public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, GetPersonDTO>
{
    private readonly IUnitOfWork _uow;

    public GetPersonDetailsQueryHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task<GetPersonDTO> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
    {
        var person = await _uow.PersonRepository.GetPersonByIdAsync(request.Id, cancellationToken);
        if (person == null)
            throw new NotFoundException($"მოცემული Id-ით {request.Id} პიროვნება ვერ მოიძებნა");

        return person.Adapt<GetPersonDTO>();
    }
}
