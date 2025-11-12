using FluentValidation;
using TBC.PersonRegistry.Application.Commons.Extensions;

namespace TBC.PersonRegistry.Application.Features.People.Commands.UploadPersonImage;

public class UploadPersonImageCommandValidator : AbstractValidator<UploadPersonImageCommand>
{
    public UploadPersonImageCommandValidator()
    {
        RuleFor(x => x.PersonId)
            .GreaterThan(0)
            .WithMessage("პირის იდენტიფიკატორი აუცილებელია.");

        RuleFor(x => x.Image)
                  .NotNull()
                  .WithMessage("სურათი აუცილებელია ატვირთვისთვის.")
                  .Must(f => f.Length > 0)
                  .WithMessage("ცარიელი ფაილის ატვირთვა დაუშვებელია.")
                  .Must(f => f.FileName.FileValidityCheck())
                  .WithMessage("მხოლოდ .jpg, .jpeg, .png, .bmp ფორმატებია დაშვებული.")
                  .Must(f => f.Length <= 2 * 1024 * 1024)
                  .WithMessage("ფაილის ზომა არ უნდა აღემატებოდეს 2MB-ს.");

    }
}
