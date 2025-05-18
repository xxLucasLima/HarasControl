using ArasControl.Domain.Interfaces;
using ArasControl.Domain.ValueObjects;
using MediatR;

namespace ArasControl.Application.Commands.Animal.Handler
{
    public class UpdateAnimalHandler : IRequestHandler<UpdateAnimalCommand, Unit>
    {
        private readonly IAnimalRepository _animalRepo;

        public UpdateAnimalHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<Unit> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = await _animalRepo.GetByIdAsync(request.Id);
            if (animal == null)
                throw new Exception("Animal não encontrado.");

            animal.Rename(request.Name);
            animal.ChangeBreed(request.Breed);
            animal.ChangeColor(request.Color);
            animal.ChangeDimensions(new AnimalDimensions(request.WeightKg, request.HeightCm));
            animal.ChangeOwner(request.OwnerId);
            animal.ChangeHaras(request.HarasId);
            animal.UpdateDateOfBirth(request.DateOfBirth);
            animal.UpdateSex(request.Sex);
            animal.UpdateMicrochipId(request.MicrochipId);
            animal.UpdateRegistrationNumber(request.RegistrationNumber);
            animal.UpdateTemperament(request.Temperament);
            animal.UpdateMedicalHistory(request.MedicalHistory);

            await _animalRepo.UpdateAsync(animal);
            return Unit.Value;
        }
    }
}
