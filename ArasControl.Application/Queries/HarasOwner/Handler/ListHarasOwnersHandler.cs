using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.HarasOwner.Handler
{
    public class ListHarasOwnersHandler : IRequestHandler<ListHarasOwnersQuery, IEnumerable<HarasOwnerDto>>
    {
        private readonly IHarasOwnerRepository _repo;

        public ListHarasOwnersHandler(IHarasOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<HarasOwnerDto>> Handle(ListHarasOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = await _repo.ListAsync();
            return owners.Select(o => new HarasOwnerDto
            {
                Id = o.Id,
                Name = o.Name,
                Email = o.Email
            });
        }
    }
}
