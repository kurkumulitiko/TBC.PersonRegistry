using FluentValidation;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Delete.PersonRelation;

public class DeletePersonRelationCommandValidator : AbstractValidator<DeletePersonRelationCommand>
{
    public DeletePersonRelationCommandValidator()
    {
        RuleFor(x => x.PersonId)
            .NotEmpty()
            .NotEqual(x => x.RelatedPersonId);

        RuleFor(x => x.RelatedPersonId)
            .NotEmpty();
    }
}
