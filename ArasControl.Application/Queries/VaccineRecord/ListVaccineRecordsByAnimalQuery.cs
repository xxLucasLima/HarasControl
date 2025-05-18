using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.VaccineRecord
{
    public class ListVaccineRecordsByAnimalQuery : IRequest<IEnumerable<VaccineRecordDto>>
    {
        public Guid AnimalId { get; set; }
        public ListVaccineRecordsByAnimalQuery(Guid animalId)
        {
            AnimalId = animalId;
        }
    }
}
