using ArasControl.Application.Commands.Animal;
using FluentValidation;

namespace ArasControl.Application.Validators.Animal
{
    public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
    {
        public CreateAnimalCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Breed).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Color).NotEmpty().MaximumLength(50);
            RuleFor(x => x.WeightKg).GreaterThan(0);
            RuleFor(x => x.HeightCm).GreaterThan(0);
            RuleFor(x => x.HarasId).NotEqual(Guid.Empty);
            RuleFor(x => x.OwnerId).NotEqual(Guid.Empty);
            RuleFor(x => x.DateOfBirth).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.MicrochipId).NotEmpty().MaximumLength(50);
            RuleFor(x => x.RegistrationNumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Temperament).NotEmpty().MaximumLength(100);
            RuleFor(x => x.MedicalHistory).NotEmpty().MaximumLength(1000);
        }
    }
}
