using ArasControl.Application.Commands.AnimalOwner;
using FluentValidation;

namespace ArasControl.Application.Validators.AnimalOwner
{
    public class DeleteAnimalOwnerCommandValidator : AbstractValidator<DeleteAnimalOwnerCommand>
    {
        public DeleteAnimalOwnerCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
        }
    }
}
