using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.AnimalOwner.Handler
{
    public class GetAnimalOwnerByIdHandler : IRequestHandler<GetAnimalOwnerByIdQuery, AnimalOwnerDto>
    {
        private readonly IAnimalOwnerRepository _repo;

        public GetAnimalOwnerByIdHandler(IAnimalOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<AnimalOwnerDto> Handle(GetAnimalOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var owner = await _repo.GetByIdAsync(request.Id);
            if (owner == null) return null;
            return new AnimalOwnerDto
            {
                Id = owner.Id,
                Name = owner.Name,
                Email = owner.Email,
                HarasId = owner.HarasId
            };
        }
    }
}
