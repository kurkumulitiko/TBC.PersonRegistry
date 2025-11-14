using MediatR;
using TBC.PersonRegistry.Application.Exceptions;
using TBC.PersonRegistry.Application.Interfaces;
using TBC.PersonRegistry.Application.Interfaces.Services;

namespace TBC.PersonRegistry.Application.Features.People.Commands.UploadPersonImage;

public class UploadPersonImageCommandHandler : IRequestHandler<UploadPersonImageCommand>
{
    private readonly IUnitOfWork _uow;
    private readonly IFileService _fileService;
    public UploadPersonImageCommandHandler(IUnitOfWork uow, IFileService fileService)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
    }

    public async Task Handle(UploadPersonImageCommand request, CancellationToken cancellationToken)
    {
        var personfromDb = await _uow.PersonRepository.GetPersonByIdAsync(request.PersonId, cancellationToken);
        if (personfromDb == null)
            throw new NotFoundException("პიროვნება ვერ მოიძებნა!");


        if (request.Image != null)
            personfromDb.ImagePath = await _fileService.UploadFileAsync(request.Image.OpenReadStream(), request.Image.FileName);

         _uow.PersonRepository.Update(personfromDb);
        await _uow.SaveAsync().ConfigureAwait(false);

    }

}
