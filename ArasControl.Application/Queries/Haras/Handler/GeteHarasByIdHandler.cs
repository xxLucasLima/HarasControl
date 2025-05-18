using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.Haras.Handler
{
    public class GetHarasByIdHandler : IRequestHandler<GetHarasByIdQuery, HarasDto>
    {
        private readonly IHarasRepository _repo;

        public GetHarasByIdHandler(IHarasRepository repo)
        {
            _repo = repo;
        }

        public async Task<HarasDto> Handle(GetHarasByIdQuery request, CancellationToken cancellationToken)
        {
            var haras = await _repo.GetByIdAsync(request.Id);
            if (haras == null) return null;
            return new HarasDto
            {
                Name = haras.Name,
                OwnerId = haras.OwnerId
            };
        }
    }
}
