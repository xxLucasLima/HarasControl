
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.VaccineRecord.Handler
{
    public class AddVaccineRecordHandler : IRequestHandler<AddVaccineRecordCommand, Guid>
    {
        private readonly IAnimalRepository _animalRepo;

        public AddVaccineRecordHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<Guid> Handle(AddVaccineRecordCommand request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.AnimalId);
            if (animal == null)
                throw new Exception("Animal não encontrado.");

            var vaccineRecord = new Domain.Entities.VaccineRecord(
                Guid.NewGuid(),
                request.AnimalId,
                request.VaccineName,
                request.AdministeredAt,
                request.NextDue,
                request.FrequencyDays,
                request.ReminderDaysBefore,
                request.ReminderEnabled,
                request.Notes
            );

            animal.AddVaccineRecord(vaccineRecord);
            await _animalRepo.UpdateAsync(animal);

            return vaccineRecord.Id;
        }
    }
}
