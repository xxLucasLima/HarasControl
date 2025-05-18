using MediatR;

namespace ArasControl.Application.Commands.VaccineRecord
{
    public class AddVaccineRecordCommand : IRequest<Guid>
    {
        public Guid AnimalId { get; set; }
        public string VaccineName { get; set; }
        public DateTime AdministeredAt { get; set; }
        public DateTime? NextDue { get; set; }
        public int? FrequencyDays { get; set; }
        public int ReminderDaysBefore { get; set; }
        public bool ReminderEnabled { get; set; }
        public string Notes { get; set; }

        public AddVaccineRecordCommand(
            Guid animalId,
            string vaccineName,
            DateTime administeredAt,
            DateTime? nextDue,
            int? frequencyDays,
            int reminderDaysBefore,
            bool reminderEnabled,
            string notes)
        {
            AnimalId = animalId;
            VaccineName = vaccineName;
            AdministeredAt = administeredAt;
            NextDue = nextDue;
            FrequencyDays = frequencyDays;
            ReminderDaysBefore = reminderDaysBefore;
            ReminderEnabled = reminderEnabled;
            Notes = notes;
        }
    }
}
