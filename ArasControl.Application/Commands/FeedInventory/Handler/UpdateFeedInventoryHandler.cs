using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArasControl.Domain.Interfaces;
using MediatR;

namespace ArasControl.Application.Commands.FeedInventory.Handler
{
    public class UpdateFeedInventoryHandler : IRequestHandler<UpdateFeedInventoryCommand, Unit>
    {
        private readonly IFeedInventoryRepository _repo;

        public UpdateFeedInventoryHandler(IFeedInventoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateFeedInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _repo.GetByAnimalIdAsync(request.Id); // Se preferir, crie um GetByIdAsync!
            if (inventory == null)
                throw new Exception("FeedInventory não encontrado.");

            inventory.UpdateCurrentQuantity(request.CurrentQuantity);
            inventory.UpdateUnit(request.Unit);
            inventory.UpdateThresholdQuantity(request.ThresholdQuantity);
            inventory.UpdateAlert(request.AlertEnabled);

            await _repo.UpdateAsync(inventory);
            return Unit.Value;
        }
    }
}
