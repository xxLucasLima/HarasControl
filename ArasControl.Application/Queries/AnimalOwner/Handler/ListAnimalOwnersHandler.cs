using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.AnimalOwner.Handler
{
    public class ListAnimalOwnersHandler : IRequestHandler<ListAnimalOwnersQuery, IEnumerable<AnimalOwnerDto>>
    {
        private readonly IAnimalOwnerRepository _repo;

        public ListAnimalOwnersHandler(IAnimalOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<AnimalOwnerDto>> Handle(ListAnimalOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = await _repo.ListByHarasAsync(Guid.Empty); // Se quiser listar todos, crie um ListAsync() no repo!
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
