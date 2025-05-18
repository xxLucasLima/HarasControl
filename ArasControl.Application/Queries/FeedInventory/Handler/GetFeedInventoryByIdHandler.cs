
using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.FeedInventory.Handler
{
    public class GetFeedInventoryByIdHandler : IRequestHandler<GetFeedInventoryByIdQuery, FeedInventoryDto>
    {
        private readonly IFeedInventoryRepository _repo;

        public GetFeedInventoryByIdHandler(IFeedInventoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<FeedInventoryDto> Handle(GetFeedInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var fi = await _repo.GetByIdAsync(request.Id);
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
