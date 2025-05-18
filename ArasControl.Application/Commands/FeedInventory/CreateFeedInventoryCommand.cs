using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.FeedInventory
{
    public class CreateFeedInventoryCommand : IRequest<Guid>
    {
        public Guid AnimalId { get; set; }
        public decimal CurrentQuantity { get; set; }
        public string Unit { get; set; }
        public decimal ThresholdQuantity { get; set; }
        public bool AlertEnabled { get; set; }

        public CreateFeedInventoryCommand(Guid animalId, decimal currentQuantity, string unit, decimal thresholdQuantity, bool alertEnabled)
        {
            AnimalId = animalId;
            CurrentQuantity = currentQuantity;
            Unit = unit;
            ThresholdQuantity = thresholdQuantity;
            AlertEnabled = alertEnabled;
        }
    }
}
