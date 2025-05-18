using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.AnimalOwner
{
    public class ListAnimalOwnersByHarasQuery : IRequest<IEnumerable<AnimalOwnerDto>>
    {
        public Guid HarasId { get; set; }
        public ListAnimalOwnersByHarasQuery(Guid harasId)
        {
            HarasId = harasId;
        }
    }
}
