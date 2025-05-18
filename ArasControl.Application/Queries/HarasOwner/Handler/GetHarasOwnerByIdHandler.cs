using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.HarasOwner.Handler
{
    public class GetHarasOwnerByIdHandler : IRequestHandler<GetHarasOwnerByIdQuery, HarasOwnerDto>
    {
        private readonly IHarasOwnerRepository _repo;

        public GetHarasOwnerByIdHandler(IHarasOwnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<HarasOwnerDto> Handle(GetHarasOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var owner = await _repo.GetByIdAsync(request.Id);
            if (owner == null) return null;
            return new HarasOwnerDto
            {
                Id = owner.Id,
                Name = owner.Name,
                Email = owner.Email
            };
        }
    }
}
