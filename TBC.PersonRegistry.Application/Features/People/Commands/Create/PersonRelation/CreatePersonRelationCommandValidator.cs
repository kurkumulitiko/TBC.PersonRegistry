using FluentValidation;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Create.PersonRelation;

public class CreatePersonRelationshipCommandValidator : AbstractValidator<CreatePersonRelationCommand>
{
    public CreatePersonRelationshipCommandValidator()
    {
        RuleFor(x => x.PersonId)
            .NotEmpty()
            .NotEqual(x => x.RelatedPersonId);

        RuleFor(x => x.RelatedPersonId)
            .NotEmpty();

        RuleFor(x => x.RelationType)
             .IsInEnum()
             .WithMessage("საჭიროა შესაბამისი ურთიერთობის ტიპის მითითება!"); //ეს მესიჯი ვნახცო მერე

    }
}

