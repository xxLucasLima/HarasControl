using ArasControl.Application.Commands.Haras;
using FluentValidation;

namespace ArasControl.Application.Validators.Haras
{
    public class CreateHarasCommandValidator : AbstractValidator<CreateHarasCommand>
    {
        public CreateHarasCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.OwnerId).NotEqual(Guid.Empty);
        }
    }
}
