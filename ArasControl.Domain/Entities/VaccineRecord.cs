using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Domain.Entities
{
    public class VaccineRecord
    {
        public Guid Id { get; private set; }
        public Guid AnimalId { get; private set; }
        public string VaccineName { get; private set; }
        public DateTime AdministeredAt { get; private set; }
        public DateTime? NextDue { get; private set; }

        /// <summary>
        /// Interval in days for the vaccine to be reapplied (e.g., annual, semi-annual).
        /// </summary>
        public int? FrequencyDays { get; private set; }
        /// <summary>
        /// Days before NextDue to trigger a reminder notification.
        /// </summary>
        public int ReminderDaysBefore { get; private set; }
        /// <summary>
        /// Whether reminder notifications are enabled for this record.
        /// </summary>
        public bool ReminderEnabled { get; private set; }
        public string Notes { get; private set; }

        public VaccineRecord(
            Guid id,
            Guid animalId,
            string vaccineName,
            DateTime administeredAt,
            DateTime? nextDue = null,
            int? frequencyDays = null,
            int reminderDaysBefore = 7,
            bool reminderEnabled = true,
            string notes = null)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid VaccineRecord Id.", nameof(id));
            if (animalId == Guid.Empty) throw new ArgumentException("AnimalId is required.", nameof(animalId));
            if (string.IsNullOrWhiteSpace(vaccineName)) throw new ArgumentException("VaccineName is required.", nameof(vaccineName));
            if (administeredAt > DateTime.UtcNow) throw new ArgumentException("AppliedAt cannot be in the future.", nameof(administeredAt));
            if (frequencyDays.HasValue && frequencyDays <= 0) throw new ArgumentException("FrequencyDays must be positive.", nameof(frequencyDays));
            if (reminderDaysBefore < 0) throw new ArgumentException("ReminderDaysBefore cannot be negative.", nameof(reminderDaysBefore));

            Id = id;
            AnimalId = animalId;
            VaccineName = vaccineName;
            AdministeredAt = administeredAt;
            NextDue = nextDue;
            FrequencyDays = frequencyDays;
            ReminderDaysBefore = reminderDaysBefore;
            ReminderEnabled = reminderEnabled;
            Notes = notes;
        }

        public DateTime? GetReminderDate()
        {
            if (!NextDue.HasValue || !ReminderEnabled) return null;
            return NextDue.Value.AddDays(-ReminderDaysBefore);
        }
    }
}
