using MediatR;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Interfaces;
using TBC.PersonRegistry.Domain.Models;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Update;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdatePersonCommandHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var personfromDb = await _uow.PersonRepository.GetPersonByIdAsync(request.PersonId, cancellationToken);
        if (personfromDb == null)
            throw new NotFoundException("პიროვნება ვერ მოიძებნა!");

        personfromDb.FirstName = request.FirstName;
        personfromDb.LastName = request.LastName;
        personfromDb.PrivateNumber = request.PrivateNumber;
        personfromDb.Gender = request.Gender;
        personfromDb.CityId = request.CityId;
        personfromDb.BirthDate = request.BirthDate;

        personfromDb.UpdatedAt = DateTime.Now;

        foreach (var phNum in personfromDb.Phones)
            phNum.DeletedAt = DateTime.Now;


        foreach (var n in request.Phones)
        {
            personfromDb.Phones.Add(new Phone
            {
                PhoneNumber = n.PhoneNumber,
                NumberType = n.NumberType,
                PersonId = personfromDb.Id,
                CreatedAt = DateTime.Now
            });
        }

         _uow.PersonRepository.Update(personfromDb); 
        await _uow.SaveAsync(cancellationToken);

    }
}

