using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Domain.Entities
{
    public class AnimalOwner
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Guid HarasId { get; private set; }

        private readonly List<Animal> _animals = new();
        public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();

        public AnimalOwner(Guid id, string name, string email, Guid harasId)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid AnimalOwner Id.", nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));
            if (harasId == Guid.Empty)
                throw new ArgumentException("HarasId is required.", nameof(harasId));

            Id = id;
            Name = name;
            Email = email;
            HarasId = harasId;
        }

        public void UpdateContact(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));

            Name = name;
            Email = email;
        }

        public void AddAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));
            if (animal.HarasId != HarasId)
                throw new ArgumentException("Animal belongs to a different Haras.", nameof(animal));

            _animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));

            _animals.Remove(animal);
        }

        public void ChangeHaras(Guid newHarasId)
        {
            if (newHarasId == Guid.Empty)
                throw new ArgumentException("HarasId is required.", nameof(newHarasId));

            HarasId = newHarasId;
            _animals.Clear();
        }
    }
}
