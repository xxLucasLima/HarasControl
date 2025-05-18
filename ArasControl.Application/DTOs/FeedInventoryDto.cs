using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Application.DTOs
{
    public class FeedInventoryDto
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public decimal CurrentQuantity { get; set; }
        public string Unit { get; set; }
        public decimal ThresholdQuantity { get; set; }
        public bool AlertEnabled { get; set; }
    }
}
