using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.VaccineRecord.Handler
{
    public class ListVaccineRecordsByAnimalHandler : IRequestHandler<ListVaccineRecordsByAnimalQuery, IEnumerable<VaccineRecordDto>>
    {
        private readonly IAnimalRepository _animalRepo;

        public ListVaccineRecordsByAnimalHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<IEnumerable<VaccineRecordDto>> Handle(ListVaccineRecordsByAnimalQuery request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.AnimalId);
            if (animal == null)
                return Enumerable.Empty<VaccineRecordDto>();

            return animal.VaccineRecords.Select(record => new VaccineRecordDto
            {
                Id = record.Id,
                AnimalId = record.AnimalId,
                VaccineName = record.VaccineName,
                AdministeredAt = record.AdministeredAt,
                NextDue = record.NextDue,
                FrequencyDays = record.FrequencyDays,
                ReminderDaysBefore = record.ReminderDaysBefore,
                ReminderEnabled = record.ReminderEnabled,
                Notes = record.Notes
            });
        }
    }
}
