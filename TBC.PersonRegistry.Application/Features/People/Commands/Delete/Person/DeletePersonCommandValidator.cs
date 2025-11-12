using FluentValidation;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Delete.Person;

public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
{
    public DeletePersonCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

