using ArasControl.Application.Commands.AnimalOwner;
using FluentValidation;

namespace ArasControl.Application.Validators.AnimalOwner
{
    public class CreateAnimalOwnerCommandValidator : AbstractValidator<CreateAnimalOwnerCommand>
    {
        public CreateAnimalOwnerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().MaximumLength(200).EmailAddress();
            RuleFor(x => x.HarasId).NotEqual(Guid.Empty);
        }
    }
}
