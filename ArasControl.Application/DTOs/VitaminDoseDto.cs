using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArasControl.Application.DTOs
{
    public class VitaminDoseDto
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public string VitaminName { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public DateTime AdministeredAt { get; set; }
        public string Notes { get; set; }
    }
}
