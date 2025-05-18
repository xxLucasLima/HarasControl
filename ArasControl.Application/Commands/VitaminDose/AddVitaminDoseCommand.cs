using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.VitaminDose
{
    public class AddVitaminDoseCommand : IRequest<Guid>
    {
        public Guid AnimalId { get; set; }
        public string VitaminName { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public DateTime AdministeredAt { get; set; }
        public string Notes { get; set; }

        public AddVitaminDoseCommand(Guid animalId, string vitaminName, decimal amount, string unit, DateTime administeredAt, string notes)
        {
            AnimalId = animalId;
            VitaminName = vitaminName;
            Amount = amount;
            Unit = unit;
            AdministeredAt = administeredAt;
            Notes = notes;
        }
    }
}
