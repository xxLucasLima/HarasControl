using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using MediatR;

namespace ArasControl.Application.Queries.Animal
{
    public class GetAnimalByIdQuery : IRequest<AnimalDto>
    {
        public Guid Id { get; set; }
        public GetAnimalByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
