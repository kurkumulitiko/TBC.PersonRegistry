using FluentValidation;
using System.Text.RegularExpressions;
using TBC.PersonRegistry.Application.Commons.Extensions;
using TBC.PersonRegistry.Application.Resources;

namespace TBC.PersonRegistry.Application.Features.People.Commands.Update;

public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonCommandValidator()
    {
        RuleFor(x => x.FirstName)
             .NotEmpty()
             .Length(2, 50)
             .Must(firstName =>
                 !string.IsNullOrWhiteSpace(firstName) &&
                 (Regex.IsMatch(firstName, "^[a-zA-Z]*$") ||
                  Regex.IsMatch(firstName, "^[ა-ჰ]*$")))
                 .WithMessage(ValidationMessagesResource.FirstNameInvalid);

        RuleFor(x => x.LastName)
           .NotEmpty()
           .Length(2, 50)
           .Must(lastName =>
               !string.IsNullOrWhiteSpace(lastName) &&
               (Regex.IsMatch(lastName, "^[a-zA-Z]*$") ||
                Regex.IsMatch(lastName, "^[ა-ჰ]*$")))
               .WithMessage(ValidationMessagesResource.LastNameInvalid);

        RuleFor(x => x.PrivateNumber)
            .NotEmpty()
            .Length(11)
            .Matches("^[0-9]*$");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .Must(x => x.PersonAgeCheck())
            .WithMessage(ValidationMessagesResource.PersonAgeInvalid);

        RuleFor(x => x.Gender)
            .NotEmpty();

    }
}



