using ArasControl.Domain.Entities.Enum;

namespace ArasControl.Application.DTOs
{
    public class AnimalDto
    {
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
    }

}
