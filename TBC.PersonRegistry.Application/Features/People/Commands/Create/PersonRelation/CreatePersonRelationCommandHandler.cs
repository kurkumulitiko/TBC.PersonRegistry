using Mapster;
using MediatR;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Interfaces;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Create.PersonRelation;

public class CreatePersonRelationCommandHandler : IRequestHandler<CreatePersonRelationCommand>
{
    private readonly IUnitOfWork _uow;
    public CreatePersonRelationCommandHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }
    public async Task Handle(CreatePersonRelationCommand request, CancellationToken cancellationToken)
    {
        if (!await _uow.PersonRepository.AnyAsync(x => x.Id == request.PersonId && x.DeletedAt == null, cancellationToken))
            throw new NotFoundException("პიროვნება გადმოცემულ Id-ზე არ არსებობს");
        else if (!await _uow.PersonRepository.AnyAsync(x => x.Id == request.RelatedPersonId && x.DeletedAt == null, cancellationToken))
            throw new NotFoundException("დაკავშირებული პიროვნება გადმოცემულ Id-ზე არ არსებობს");

        var personRelation = request.Adapt<Domain.Models.PersonRelation>();
        personRelation.CreatedAt = DateTime.Now;

        await _uow.PersonRepository.AddRelatedPerson(personRelation);
        await _uow.SaveAsync();

    }
}

