using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.AnimalOwner.Handler
{
    public class ListAnimalOwnersByHarasHandler : IRequestHandler<ListAnimalOwnersByHarasQuery, IEnumerable<AnimalOwnerDto>>
    {
        private readonly IAnimalOwnerRepository _repo;

        public ListAnimalOwnersByHarasHandler(IAnimalOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AnimalOwnerDto>> Handle(ListAnimalOwnersByHarasQuery request, CancellationToken cancellationToken)
        {
            var owners = await _repo.ListByHarasAsync(request.HarasId);
            return owners.Select(o => new AnimalOwnerDto
            {
                Id = o.Id,
                Name = o.Name,
                Email = o.Email,
                HarasId = o.HarasId
            });
        }
    }
}
