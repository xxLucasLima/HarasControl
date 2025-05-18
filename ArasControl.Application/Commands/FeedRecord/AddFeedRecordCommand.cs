using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ArasControl.Application.Commands.FeedRecord
{
    public class AddFeedRecordCommand : IRequest<Guid>
    {
        public Guid AnimalId { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public DateTime FedAt { get; set; }
        public string Notes { get; set; }

        public AddFeedRecordCommand(Guid animalId, decimal amount, string unit, DateTime fedAt, string notes)
        {
            AnimalId = animalId;
            Amount = amount;
            Unit = unit;
            FedAt = fedAt;
            Notes = notes;
        }
    }
}
