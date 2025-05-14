using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Domain.Entities
{
    /// <summary>
    /// Mantém o estoque de ração disponível para o animal e dispara alerta quando abaixo do limiar.
    /// </summary>
    public class FeedInventory
    {
        /// <summary>Identificador único do estoque de ração.</summary>
        public Guid Id { get; private set; }

        /// <summary>Identificador do animal associado a este estoque.</summary>
        public Guid AnimalId { get; private set; }

        /// <summary>Quantidade atual de ração em estoque.</summary>
        public decimal CurrentQuantity { get; private set; }

        /// <summary>Unidade de medida do estoque (ex.: "kg").</summary>
        public string Unit { get; private set; }

        /// <summary>
        /// Quantidade mínima antes de disparar alerta de estoque baixo.
        /// </summary>
        public decimal ThresholdQuantity { get; private set; }

        /// <summary>
        /// Indica se o sistema deve disparar alerta quando o estoque estiver baixo.
        /// </summary>
        public bool AlertEnabled { get; private set; }

        public FeedInventory(Guid id, Guid animalId, decimal initialQuantity, string unit, decimal thresholdQuantity, bool alertEnabled = true)
        {
            if (id == Guid.Empty) throw new ArgumentException("Invalid FeedInventory Id.", nameof(id));
            if (animalId == Guid.Empty) throw new ArgumentException("AnimalId is required.", nameof(animalId));
            if (initialQuantity < 0) throw new ArgumentException("InitialQuantity cannot be negative.", nameof(initialQuantity));
            if (string.IsNullOrWhiteSpace(unit)) throw new ArgumentException("Unit is required.", nameof(unit));
            if (thresholdQuantity < 0) throw new ArgumentException("ThresholdQuantity cannot be negative.", nameof(thresholdQuantity));

            Id = id;
            AnimalId = animalId;
            CurrentQuantity = initialQuantity;
            Unit = unit;
            ThresholdQuantity = thresholdQuantity;
            AlertEnabled = alertEnabled;
        }

        /// <summary>Aumenta o estoque em uma quantidade especificada.</summary>
        public void AddStock(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            CurrentQuantity += amount;
        }

        /// <summary>
        /// Consome uma quantidade do estoque e retorna verdadeiro se o nível
        /// atual ficar abaixo do ThresholdQuantity (para disparar alerta).
        /// </summary>
        public bool Consume(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.", nameof(amount));
            if (amount > CurrentQuantity) throw new InvalidOperationException("Not enough stock.");

            CurrentQuantity -= amount;
            return AlertEnabled && CurrentQuantity <= ThresholdQuantity;
        }
    }
}
