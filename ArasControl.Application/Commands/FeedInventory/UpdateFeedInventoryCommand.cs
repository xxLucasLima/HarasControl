using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.FeedInventory
{
    public class UpdateFeedInventoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public decimal CurrentQuantity { get; set; }
        public string Unit { get; set; }
        public decimal ThresholdQuantity { get; set; }
        public bool AlertEnabled { get; set; }

        public UpdateFeedInventoryCommand(Guid id, decimal currentQuantity, string unit, decimal thresholdQuantity, bool alertEnabled)
        {
            Id = id;
            CurrentQuantity = currentQuantity;
            Unit = unit;
            ThresholdQuantity = thresholdQuantity;
            AlertEnabled = alertEnabled;
        }
    }
}
