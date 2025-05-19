using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Domain.Entities
{
    /// <summary>
    /// Registra cada alimentação do animal, mantendo um histórico de consumo.
    /// </summary>
    public class FeedRecord
    {
        /// <summary>Identificador único do registro de alimentação.</summary>
        public Guid Id { get; private set; }

        /// <summary>Identificador do animal que foi alimentado.</summary>
        public Guid AnimalId { get; private set; }

        /// <summary>Quantidade de ração fornecida.</summary>
        public decimal Amount { get; private set; }

        /// <summary>Unidade de medida da ração (ex.: "kg").</summary>
        public string Unit { get; private set; }

        /// <summary>Data e hora em que o animal foi alimentado.</summary>
        public DateTime FedAt { get; private set; }

        /// <summary>Observações adicionais (lote, marca, etc.).</summary>
        public string? Notes { get; private set; }

        public FeedRecord(Guid id, Guid animalId, decimal amount, string unit, DateTime fedAt, string notes = null)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid FeedRecord Id.", nameof(id));
            if (animalId == Guid.Empty) throw new ArgumentException("AnimalId is required.", nameof(animalId));
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            if (string.IsNullOrWhiteSpace(unit)) throw new ArgumentException("Unit is required.", nameof(unit));
            if (fedAt > DateTime.UtcNow) throw new ArgumentException("FedAt cannot be in the future.", nameof(fedAt));

            Id = id;
            AnimalId = animalId;
            Amount = amount;
            Unit = unit;
            FedAt = fedAt;
            Notes = notes;
        }
    }
}
