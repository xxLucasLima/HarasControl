using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.VitaminDose.Handler
{
    public class AddVitaminDoseHandler : IRequestHandler<AddVitaminDoseCommand, Guid>
    {
        private readonly IAnimalRepository _animalRepo;

        public AddVitaminDoseHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<Guid> Handle(AddVitaminDoseCommand request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.AnimalId);
            if (animal == null)
                throw new Exception("Animal não encontrado.");

            var vitaminDose = new Domain.Entities.VitaminDose(
                Guid.NewGuid(),
                request.AnimalId,
                request.VitaminName,
                request.Amount,
                request.Unit,
                request.AdministeredAt,
                request.Notes
            );

            animal.AddVitaminDose(vitaminDose);
            await _animalRepo.UpdateAsync(animal);

            return vitaminDose.Id;
        }
    }
}
