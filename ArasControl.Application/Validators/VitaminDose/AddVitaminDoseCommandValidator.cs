using ArasControl.Application.Commands.VitaminDose;
using FluentValidation;

namespace ArasControl.Application.Validators.VitaminDose
{
    public class AddVitaminDoseCommandValidator : AbstractValidator<AddVitaminDoseCommand>
    {
        public AddVitaminDoseCommandValidator()
        {
            RuleFor(x => x.AnimalId).NotEqual(Guid.Empty);
            RuleFor(x => x.VitaminName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Unit).NotEmpty().MaximumLength(20);
            RuleFor(x => x.AdministeredAt).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.Notes).MaximumLength(300);
        }
    }
}
