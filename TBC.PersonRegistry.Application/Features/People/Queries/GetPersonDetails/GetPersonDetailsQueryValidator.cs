using FluentValidation;

namespace TBC.PersonRegistry.Application.Features.People.Queries.GetPersonDetails;

public class GetPersonDetailsQueryValidator : AbstractValidator<GetPersonDetailsQuery>
{
    public GetPersonDetailsQueryValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}
