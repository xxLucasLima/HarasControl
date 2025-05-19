using ArasControl.Domain.Entities.Enum;
using ArasControl.Domain.ValueObjects;

namespace ArasControl.Domain.Entities
{
    public class Animal
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Breed { get; private set; }
        public string Color { get; private set; }
        public AnimalDimensions Dimensions { get; private set; }
        public Guid HarasId { get; private set; }
        public Guid OwnerId { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Sex { get; private set; }
        public string MicrochipId { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string Temperament { get; private set; }
        public string MedicalHistory { get; private set; }

        private readonly List<VitaminDose> _vitaminDoses = new();
        public IReadOnlyCollection<VitaminDose> VitaminDoses => _vitaminDoses.AsReadOnly();

        private readonly List<FeedRecord> _feedRecords = new();
        public IReadOnlyCollection<FeedRecord> FeedRecords => _feedRecords.AsReadOnly();

        private readonly List<VaccineRecord> _vaccineRecords = new();
        public IReadOnlyCollection<VaccineRecord> VaccineRecords => _vaccineRecords.AsReadOnly();


        protected Animal() { }

        public Animal(
            Guid id,
            string name,
            string breed,
            string color,
            AnimalDimensions dimensions,
            Guid harasId,
            Guid ownerId,
            DateTime dateOfBirth,
            Gender sex,
            string microchipId,
            string registrationNumber,
            string temperament,
            string medicalHistory)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid Animal Id.", nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Animal name is required.", nameof(name));
            if (string.IsNullOrWhiteSpace(breed))
                throw new ArgumentException("Breed is required.", nameof(breed));
            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentException("Color is required.", nameof(color));
            if (dimensions == null)
                throw new ArgumentNullException(nameof(dimensions), "Dimensions are required.");
            if (harasId == Guid.Empty)
                throw new ArgumentException("HarasId is required.", nameof(harasId));
            if (ownerId == Guid.Empty)
                throw new ArgumentException("OwnerId is required.", nameof(ownerId));
            if (dateOfBirth > DateTime.UtcNow)
                throw new ArgumentException("DateOfBirth cannot be in the future.", nameof(dateOfBirth));
            if (string.IsNullOrWhiteSpace(microchipId))
                throw new ArgumentException("MicrochipId is required.", nameof(microchipId));
            if (string.IsNullOrWhiteSpace(registrationNumber))
                throw new ArgumentException("RegistrationNumber is required.", nameof(registrationNumber));
            if (string.IsNullOrWhiteSpace(temperament))
                throw new ArgumentException("Temperament is required.", nameof(temperament));
            if (string.IsNullOrWhiteSpace(medicalHistory))
                throw new ArgumentException("MedicalHistory is required.", nameof(medicalHistory));

            Id = id;
            Name = name;
            Breed = breed;
            Color = color;
            Dimensions = dimensions;
            HarasId = harasId;
            OwnerId = ownerId;
            DateOfBirth = dateOfBirth;
            Sex = sex;
            MicrochipId = microchipId;
            RegistrationNumber = registrationNumber;
            Temperament = temperament;
            MedicalHistory = medicalHistory;
        }
        public void AddVitaminDose(VitaminDose dose)
        {
            if (dose == null) throw new ArgumentNullException(nameof(dose));
            if (dose.AnimalId != this.Id)
                throw new ArgumentException("Dose pertence a outro animal.", nameof(dose));
            _vitaminDoses.Add(dose);
        }
        public void AddVaccineRecord(VaccineRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            if (record.AnimalId != this.Id) throw new ArgumentException("VaccineRecord belongs to another animal.", nameof(record));
            _vaccineRecords.Add(record);
        }
        public void AddFeedRecord(FeedRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            if (record.AnimalId != this.Id)
                throw new ArgumentException("FeedRecord pertence a outro animal.", nameof(record));

            _feedRecords.Add(record);
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Animal name is required.", nameof(newName));
            Name = newName;
        }

        public void ChangeBreed(string newBreed)
        {
            if (string.IsNullOrWhiteSpace(newBreed))
                throw new ArgumentException("Breed is required.", nameof(newBreed));
            Breed = newBreed;
        }

        public void ChangeColor(string newColor)
        {
            if (string.IsNullOrWhiteSpace(newColor))
                throw new ArgumentException("Color is required.", nameof(newColor));
            Color = newColor;
        }

        public void ChangeDimensions(AnimalDimensions newDimensions)
        {
            Dimensions = newDimensions ?? throw new ArgumentNullException(nameof(newDimensions), "Dimensions are required.");
        }

        public void ChangeOwner(Guid newOwnerId)
        {
            if (newOwnerId == Guid.Empty)
                throw new ArgumentException("OwnerId is required.", nameof(newOwnerId));
            OwnerId = newOwnerId;
        }

        public void ChangeHaras(Guid newHarasId)
        {
            if (newHarasId == Guid.Empty)
                throw new ArgumentException("HarasId is required.", nameof(newHarasId));
            HarasId = newHarasId;
        }

        public void UpdateDateOfBirth(DateTime newDateOfBirth)
        {
            if (newDateOfBirth > DateTime.UtcNow)
                throw new ArgumentException("DateOfBirth cannot be in the future.", nameof(newDateOfBirth));
            DateOfBirth = newDateOfBirth;
        }

        public void UpdateSex(Gender newSex)
        {
            Sex = newSex;
        }

        public void UpdateMicrochipId(string newMicrochipId)
        {
            if (string.IsNullOrWhiteSpace(newMicrochipId))
                throw new ArgumentException("MicrochipId is required.", nameof(newMicrochipId));
            MicrochipId = newMicrochipId;
        }

        public void UpdateRegistrationNumber(string newRegistrationNumber)
        {
            if (string.IsNullOrWhiteSpace(newRegistrationNumber))
                throw new ArgumentException("RegistrationNumber is required.", nameof(newRegistrationNumber));
            RegistrationNumber = newRegistrationNumber;
        }

        public void UpdateTemperament(string newTemperament)
        {
            if (string.IsNullOrWhiteSpace(newTemperament))
                throw new ArgumentException("Temperament is required.", nameof(newTemperament));
            Temperament = newTemperament;
        }

        public void UpdateMedicalHistory(string newMedicalHistory)
        {
            if (string.IsNullOrWhiteSpace(newMedicalHistory))
                throw new ArgumentException("MedicalHistory is required.", nameof(newMedicalHistory));
            MedicalHistory = newMedicalHistory;
        }
    }
}
