using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Application.DTOs
{
    public class VaccineRecordDto
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public string VaccineName { get; set; }
        public DateTime AdministeredAt { get; set; }
        public DateTime? NextDue { get; set; }
        public int? FrequencyDays { get; set; }
        public int ReminderDaysBefore { get; set; }
        public bool ReminderEnabled { get; set; }
        public string Notes { get; set; }
    }
}
