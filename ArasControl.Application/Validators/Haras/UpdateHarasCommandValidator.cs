using ArasControl.Application.Commands.Haras;
using FluentValidation;

namespace ArasControl.Application.Validators.Haras
{
    public class UpdateHarasCommandValidator : AbstractValidator<UpdateHarasCommand>
    {
        public UpdateHarasCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
