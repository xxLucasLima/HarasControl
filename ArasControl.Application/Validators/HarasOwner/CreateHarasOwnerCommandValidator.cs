using ArasControl.Application.Commands.HarasOwner;
using FluentValidation;

namespace ArasControl.Application.Validators.HarasOwner
{
    public class CreateHarasOwnerCommandValidator : AbstractValidator<CreateHarasOwnerCommand>
    {
        public CreateHarasOwnerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(200).EmailAddress();
        }
    }
}
