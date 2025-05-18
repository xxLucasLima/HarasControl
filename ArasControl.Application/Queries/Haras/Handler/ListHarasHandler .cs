using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.Haras.Handler
{
    public class ListHarasHandler : IRequestHandler<ListHarasQuery, IEnumerable<HarasDto>>
    {
        private readonly IHarasRepository _repo;

        public ListHarasHandler(IHarasRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<HarasDto>> Handle(ListHarasQuery request, CancellationToken cancellationToken)
        {
            var harasList = await _repo.ListAsync();
            return harasList.Select(h => new HarasDto
            {
                Name = h.Name,
                OwnerId = h.OwnerId
            });
        }
    }
}
