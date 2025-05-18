using ArasControl.Application.Commands.VaccineRecord;
using FluentValidation;

namespace ArasControl.Application.Validators.VaccineRecord
{
    public class AddVaccineRecordCommandValidator : AbstractValidator<AddVaccineRecordCommand>
    {
        public AddVaccineRecordCommandValidator()
        {
            RuleFor(x => x.AnimalId).NotEqual(Guid.Empty);
            RuleFor(x => x.VaccineName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.AdministeredAt).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(x => x.NextDue).GreaterThanOrEqualTo(x => x.AdministeredAt).When(x => x.NextDue.HasValue);
            RuleFor(x => x.FrequencyDays).GreaterThan(0).When(x => x.FrequencyDays.HasValue);
            RuleFor(x => x.ReminderDaysBefore).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Notes).MaximumLength(300);
        }
    }
}
