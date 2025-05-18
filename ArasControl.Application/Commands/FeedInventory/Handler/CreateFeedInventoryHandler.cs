using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.FeedInventory.Handler
{
    public class CreateFeedInventoryHandler : IRequestHandler<CreateFeedInventoryCommand, Guid>
    {
        private readonly IFeedInventoryRepository _repo;

        public CreateFeedInventoryHandler(IFeedInventoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateFeedInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = new Domain.Entities.FeedInventory(Guid.NewGuid(), request.AnimalId, request.CurrentQuantity, request.Unit, request.ThresholdQuantity, request.AlertEnabled);
            await _repo.AddAsync(inventory);
            return inventory.Id;
        }
    }
}
