using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.FeedInventory.Handler
{
    public class GetFeedInventoryByAnimalIdHandler : IRequestHandler<GetFeedInventoryByAnimalIdQuery, FeedInventoryDto>
    {
        private readonly IFeedInventoryRepository _repo;

        public GetFeedInventoryByAnimalIdHandler(IFeedInventoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<FeedInventoryDto> Handle(GetFeedInventoryByAnimalIdQuery request, CancellationToken cancellationToken)
        {
            var fi = await _repo.GetByAnimalIdAsync(request.AnimalId);
            if (fi == null) return null;
            return new FeedInventoryDto
            {
                Id = fi.Id,
                AnimalId = fi.AnimalId,
                CurrentQuantity = fi.CurrentQuantity,
                Unit = fi.Unit,
                ThresholdQuantity = fi.ThresholdQuantity,
                AlertEnabled = fi.AlertEnabled
            };
        }
    }
}
