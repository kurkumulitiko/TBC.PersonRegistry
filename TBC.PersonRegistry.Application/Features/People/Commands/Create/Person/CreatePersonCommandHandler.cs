using Mapster;
using MediatR;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Interfaces;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Create.Person
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IUnitOfWork _uow;
        public CreatePersonCommandHandler(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }


        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var personInDb = await _uow.PersonRepository.AnyAsync(x => x.PrivateNumber == request.PrivateNumber.Trim() && x.DeletedAt != null, cancellationToken).ConfigureAwait(false); 
            if (personInDb)
                throw new AlreadyExistsException($"მოცემული პირადი ნომრით {request.PrivateNumber} პიროვნება უკვე არსებობს");

            var cityInDb = !await _uow.CityRepository.AnyAsync(x => x.Id == request.CityId, cancellationToken).ConfigureAwait(false); ;
            if (cityInDb)
                throw new NotFoundException($"მოცემული Id-ით {request.CityId} ქალაქი ვერ მოიძებნა");

            var person = request.Adapt<Domain.Models.Person>();
            person.CreatedAt = DateTime.Now;


            foreach (var phone in person.Phones)
                phone.CreatedAt = DateTime.Now;
            

            await _uow.PersonRepository.CreateAsync(person).ConfigureAwait(false);
            await _uow.SaveAsync(cancellationToken).ConfigureAwait(false);

            return person.Id;

        }
    }
}
