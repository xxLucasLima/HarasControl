using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.Haras;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.Animal.Handler
{
    public class ListAnimalsHandler : IRequestHandler<ListAnimalsQuery, IEnumerable<AnimalDto>>
    {
        private readonly IAnimalRepository _repo;

        public ListAnimalsHandler(IAnimalRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AnimalDto>> Handle(ListAnimalsQuery request, CancellationToken cancellationToken)
        {
            var animalsList = await _repo.ListAsync();
            return animalsList.Select(h => new AnimalDto
            {
                Name = h.Name,
                OwnerId = h.OwnerId
            });
        }
    }
}