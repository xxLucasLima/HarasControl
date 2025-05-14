using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Domain.Entities
{
    public class VitaminDose
    {
        public Guid Id { get; private set; }
        public Guid AnimalId { get; private set; }
        public string VitaminName { get; private set; }
        public decimal Amount { get; private set; }
        public string Unit { get; private set; }
        public DateTime AppliedAt { get; private set; }
        public string Notes { get; private set; }

        public VitaminDose(
            Guid id,
            Guid animalId,
            string vitaminName,
            decimal amount,
            string unit,
            DateTime appliedAt,
            string notes = null)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid VitaminDose Id.", nameof(id));
            if (animalId == Guid.Empty) throw new ArgumentException("AnimalId is required.", nameof(animalId));
            if (string.IsNullOrWhiteSpace(vitaminName)) throw new ArgumentException("VitaminName is required.", nameof(vitaminName));
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            if (string.IsNullOrWhiteSpace(unit)) throw new ArgumentException("Unit is required.", nameof(unit));
            if (appliedAt > DateTime.UtcNow) throw new ArgumentException("AppliedAt cannot be in the future.", nameof(appliedAt));

            Id = id;
            AnimalId = animalId;
            VitaminName = vitaminName;
            Amount = amount;
            Unit = unit;
            AppliedAt = appliedAt;
            Notes = notes;
        }
    }
}
