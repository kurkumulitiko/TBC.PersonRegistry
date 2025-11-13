using MediatR;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Interfaces;
namespace TBC.PersonRegistry.Application.Features.People.Commands.Delete.Person;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IUnitOfWork _uow;

    public DeletePersonCommandHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var personFromDb = await _uow.PersonRepository.GetPersonByIdAsync(request.Id, cancellationToken);
        if (personFromDb == null)
            throw new NotFoundException("პიროვნება ვერ მოიძებნა!");

        personFromDb.DeletedAt = DateTime.Now;
        foreach (var phNum in personFromDb.Phones)
            phNum.DeletedAt = DateTime.Now;

        foreach (var item in personFromDb.RelatedPeople)
            item.DeletedAt = DateTime.Now;
        
        _uow.PersonRepository.Update(personFromDb);
        await _uow.SaveAsync();

    }
}

