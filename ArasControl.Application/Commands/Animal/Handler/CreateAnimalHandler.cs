using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Interfaces;
using ArasControl.Domain.ValueObjects;
using MediatR;

namespace ArasControl.Application.Commands.Animal.Handler
{
    public class CreateAnimalHandler : IRequestHandler<CreateAnimalCommand, Guid>
    {
        private readonly IAnimalRepository _animalRepo;

        public CreateAnimalHandler(IAnimalRepository animalRepo)
        {
            _animalRepo = animalRepo;
        }

        public async Task<Guid> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var dimensions = new AnimalDimensions(request.WeightKg, request.HeightCm);

            var animal = new Domain.Entities.Animal(
                Guid.NewGuid(),
                request.Name,
                request.Breed,
                request.Color,
                dimensions,
                request.HarasId,
                request.OwnerId,
                request.DateOfBirth,
                request.Sex,
                request.MicrochipId,
                request.RegistrationNumber,
                request.Temperament,
                request.MedicalHistory
            );

            await _animalRepo.AddAsync(animal);
            return animal.Id;
        }
    }
}
