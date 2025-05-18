using ArasControl.Application.DTOs;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Queries.FeedInventory.Handler
{
    public class ListAllFeedInventoriesHandler : IRequestHandler<ListAllFeedInventoriesQuery, IEnumerable<FeedInventoryDto>>
    {
        private readonly IFeedInventoryRepository _repo;

        public ListAllFeedInventoriesHandler(IFeedInventoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<FeedInventoryDto>> Handle(ListAllFeedInventoriesQuery request, CancellationToken cancellationToken)
        {
            var list = await _repo.ListAsync(); // crie esse método no repo!
            return list.Select(fi => new FeedInventoryDto
            {
                Id = fi.Id,
                AnimalId = fi.AnimalId,
                CurrentQuantity = fi.CurrentQuantity,
                Unit = fi.Unit,
                ThresholdQuantity = fi.ThresholdQuantity,
                AlertEnabled = fi.AlertEnabled
            });
        }
    }
}
