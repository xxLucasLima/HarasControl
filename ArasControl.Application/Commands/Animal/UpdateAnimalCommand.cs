    using ArasControl.Domain.Entities.Enum;
using MediatR;

namespace ArasControl.Application.Commands.Animal
{
    public class UpdateAnimalCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public double WeightKg { get; set; }
        public double HeightCm { get; set; }
        public Guid HarasId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Sex { get; set; }
        public string MicrochipId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Temperament { get; set; }
        public string MedicalHistory { get; set; }

        public UpdateAnimalCommand(
            Guid id,
            string name,
            string breed,
            string color,
            double weightKg,
            double heightCm,
            Guid harasId,
            Guid ownerId,
            DateTime dateOfBirth,
            Gender sex,
            string microchipId,
            string registrationNumber,
            string temperament,
            string medicalHistory)
        {
            Id = id;
            Name = name;
            Breed = breed;
            Color = color;
            WeightKg = weightKg;
            HeightCm = heightCm;
            HarasId = harasId;
            OwnerId = ownerId;
            DateOfBirth = dateOfBirth;
            Sex = sex;
            MicrochipId = microchipId;
            RegistrationNumber = registrationNumber;
            Temperament = temperament;
            MedicalHistory = medicalHistory;
        }
    }
}
