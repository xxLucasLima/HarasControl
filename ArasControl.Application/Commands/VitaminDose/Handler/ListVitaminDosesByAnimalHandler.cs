using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.VitaminDose.Handler
{
    public class ListVitaminDosesByAnimalHandler : IRequestHandler<ListVitaminDosesByAnimalQuery, IEnumerable<VitaminDoseDto>>
    {
        private readonly IAnimalRepository _animalRepo;

        public ListVitaminDosesByAnimalHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<IEnumerable<VitaminDoseDto>> Handle(ListVitaminDosesByAnimalQuery request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.AnimalId);
            if (animal == null)
                return Enumerable.Empty<VitaminDoseDto>();

            return animal.VitaminDoses.Select(dose => new VitaminDoseDto
            {
                Id = dose.Id,
                AnimalId = dose.AnimalId,
                VitaminName = dose.VitaminName,
                Amount = dose.Amount,
                Unit = dose.Unit,
                AdministeredAt = dose.AdministeredAt,
                Notes = dose.Notes
            });
        }
    }
}