using MediatR;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Interfaces;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Delete.PersonRelation;

public class DeletePersonRelationCommandHandler : IRequestHandler<DeletePersonRelationCommand>
{
    private readonly IUnitOfWork _uow;

    public DeletePersonRelationCommandHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task Handle(DeletePersonRelationCommand request, CancellationToken cancellationToken)
    {
        if (!await _uow.PersonRepository.AnyAsync(x => x.Id == request.PersonId && x.DeletedAt == null, cancellationToken))
            throw new NotFoundException("პიროვნება გადმოცემულ Id-ზე არ არსებობს");
        else if (!await _uow.PersonRepository.AnyAsync(x => x.Id == request.RelatedPersonId && x.DeletedAt == null, cancellationToken))
            throw new NotFoundException("დაკავშირებული პიროვნება გადმოცემულ Id-ზე არ არსებობს");


        var personRelation = await _uow.PersonRepository.GetRelationByPersonAndRelatedPersonIdAsync(request.PersonId, request.RelatedPersonId, cancellationToken);
        if (personRelation == null)
            throw new NotFoundException("კავშირი ვერ მოიძებნა!");

        personRelation.DeletedAt = DateTime.Now;

        await _uow.PersonRepository.DeleteRelation(personRelation);
        await _uow.SaveAsync();

    }
}
